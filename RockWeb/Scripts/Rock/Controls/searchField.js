﻿(function () {
    'use strict';
    window.Rock = window.Rock || {};
    Rock.controls = Rock.controls || {};

    Rock.controls.searchField = (function () {
        var exports,
            SearchField = function (options) {
                this.controlId = options.controlId;
                this.$el = $('#' + this.controlId);
                this.name = options.name;
            };

        SearchField.prototype = {
            constructor: SearchField,
            initialize: function () {
                var self = this;

                var key = sessionStorage.getItem("com.rockrms.search");
                if (key && key != '') {
                    var $search = self.$el.parents('.smartsearch');
                    $search.find('input:hidden').val(key);
                    $search.find('a.dropdown-toggle > span').html($search.find('li[data-key="' + key + '"] > a').html());
                }

                this.$el.typeahead({
                    name: this.name,
                    limit: 15,
                    remote: {
                        url: Rock.settings.get('baseUrl') + 'api/search?type=%TYPE&term=%QUERY&$top=15',
                        replace: function (url, uriEncodedQuery) {
                            var query = url;
                            query = query.replace('%TYPE', self.$el.parents('.smartsearch').find('input:hidden').val());
                            query = query.replace('%QUERY', uriEncodedQuery);
                            return query;
                        }
                    }
                });

                this.initializeEventHandlers();
            },
            initializeEventHandlers: function () {
                var self = this,
                    search = function (term) {

                        // clear the selected item from the input as it might have HTML which would show while the search page loads
                        var searchControl = document.getElementById(self.controlId);
                        searchControl.value = '';

                        // search for data elements in the search term
                        var $dataEl = $("<p>" + term + "</p>").find("data").first();

                        // see if this is a universal search by looking for return-type and return-id data params
                        var returnType = $dataEl.attr("return-type");
                        var returnId = $dataEl.attr("return-id");

                        if (returnType == null || returnId == null) {
                            var otherParams = '';

                            // take any data attributes and add them as query parameters to the url
                            $dataEl.each(function () {
                                $.each(this.attributes, function () {
                                    if (this) {
                                        otherParams += '&' + this.name + '=' + encodeURIComponent(this.value);
                                    }
                                });
                            });

                            // remove any search accessories. These are html elements with the class .search-accessory
                            var resultElement = document.createElement('div');
                            resultElement.innerHTML = term;
                            //var resultElement = $("<div/>").html(term);
                            var accessories = resultElement.getElementsByClassName('search-accessory');

                            // remove all accessory elements
                            while (accessories[0]) { 
                                accessories[0].parentNode.removeChild(accessories[0]);
                            }

                            // remove any html from the search term before putting it in the url
                            var targetTerm = resultElement.textContent.trim();

                            var keyVal = self.$el.parents('.smartsearch').find('input:hidden').val(),
                                $li = self.$el.parents('.smartsearch').find('li[data-key="' + keyVal + '"]'),
                                targetUrl = $li.attr('data-target'),
                                url = Rock.settings.get('baseUrl') + targetUrl.replace('{0}', encodeURIComponent(targetTerm));

                            if (otherParams != '') {
                                if (url.indexOf('?') > -1) {
                                    url += otherParams
                                } else {
                                    url += otherParams.replace(/^&/, '?')
                                }
                            }

                            window.location = url;
                        } else {
                            // universal search uses returnType and returnId, so build the url for that
                            var keyVal = self.$el.parents('.smartsearch').find('input:hidden').val(),
                                $li = self.$el.parents('.smartsearch').find('li[data-key="' + keyVal + '"]'),
                                targetUrl = $li.attr('data-target'),
                                url = Rock.settings.get('baseUrl') + targetUrl.replace('{0}', encodeURIComponent(returnType) + "/" + encodeURIComponent(returnId));

                            window.location = url;
                        }
                    };

                // Listen for typeahead's custom events and trigger search when hit
                this.$el.on('typeahead:selected typeahead:autocompleted', function (e, obj, name) {
                    search(obj.value);
                });

                // Listen for the ENTER key being pressed while in the search box and trigger search when hit
                this.$el.on('keydown', function (e) {
                    if (e.keyCode === 13) {
                        e.preventDefault();
                        return false;
                    }
                });
                this.$el.on('keyup', function (e) {
                    if (e.keyCode === 13 && "" !== $(this).val().trim() ) {
                        search($(this).val());
                    }
                });

                // Wire up "change" handler for search type "dropdown menu"
                this.$el.parents('.smartsearch').find('.dropdown-menu a').on('click', function () {
                    var $this = $(this),
                        text = $this.html();

                    var key = $this.parent().attr('data-key');
                    sessionStorage.setItem("com.rockrms.search", key);

                    $this.parents('.dropdown-menu').siblings('.navbar-link').find('span').html(text);
                    self.$el.parents('.smartsearch').find('input:hidden').val(key)
                });
            }
        };

        exports = {
            defaults: {
                controlId: null,
                name: 'search'
            },
            controls: {},
            initialize: function (options) {
                var searchField,
                    settings = $.extend({}, exports.defaults, options);

                if (!settings.controlId) throw 'controlId is required';

                if (!exports.controls[settings.controlId]) {
                    searchField = new SearchField(settings);
                    exports.controls[settings.controlId] = searchField;
                } else {
                    searchField = exports.controls[settings.controlId];
                }

                // Delay initialization until after the DOM is ready
                $(function () {
                    searchField.initialize();
                });
            }
        };

        return exports;
    }());
}());
