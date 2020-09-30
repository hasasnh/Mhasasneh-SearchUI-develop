(function($) {
    $(document).ready(function() {
        // appending data to Table 
        var appendTable = function(tableBody) {
            var table = $('table.fl-table');
            table.find('tbody').html(tableBody);
        };

        var drawTable = function(result) {
            var tableBody = '';
            $.each(result, function(index) {
                tableBody += '<tr data-facet-name="' + result[index].FacetsName + '">\
                <td>' + result[index].Name + '</td>\
                <td>' + result[index].Title + '</td>\
                <td>' + result[index].FirstName + '</td>\
                <td>' + result[index].SecoundName + '</td>\
                <td>' + result[index].SmallDesc + '</td></tr>';
            });
            appendTable(tableBody);
        };

        function fetchJson(facetsFiltered, filteredValue) {
            $.ajax({
                url: '/SearchUI/SearchUIAjax',
                type: 'POST',
                data: {search:$('#customSearchInput').val()},
                dataType: 'json',
                success: function(data) {
                    if (facetsFiltered) {
                        var filteredData = [];
                        $.each(filteredValue, function(i) {
                            var filterResult = $.grep(data.SearchResultItems, function(item) {
                                return item.FacetsName == filteredValue[i];
                            });
                            $.merge(filteredData, filterResult);
                        });
                        $('.fl-table').DataTable().destroy();
                        drawTable(filteredData);
                    } else {
                        drawTable(data.SearchResultItems);
                        drawFacets(data.Facets);
                    }
                    $('.fl-table').DataTable({
                        "pageLength": 3
                    });
                }
            });
        };

        var searchInput = function () {
            $(document).on('click', '.searchButton_stopAjacCall', function (element) {
                var value = $(element.currentTarget).siblings('.searchInput').val();
                fetchJson(false, value);
            });
        };
        searchInput();
       

        // End Appending data to table 

        // search Filtering data
        var searchFilter = function() {;
            $(".searchInput").on("keyup", function() {
                var value = $(this).val();
                $('.fl-table.dataTable').DataTable().search(value).draw();
            });
        };
        searchFilter();
        //

        // Handle Facets \\

        var drawFacets = function(data) {
            var category = '';
            if (data) {
                $.each(data, function(index) {
                    var value = data[index].Values;
                    category += '<h3>' + data[index].Name + '</h3>'
                    $.each(value, function(index) {
                        category += '<label for="' + value[index].Name + '"><input type="checkbox" id="' + value[index].Name + '" name="' + value[index].Name + '"/>' + value[index].Name + '<span class="badge badge-secondary">' + value[index].AggregateCount + '</span></label>';
                    });
                });
                appendFacets(data, category);
            }
        };

        var appendFacets = function(data, category) {
            var facets = $('.facets');
            (data && facets.children().length == 0) ? facets.append(category): facets.hide();
        };

        var facetsCheck = function() {
            $(document).on('change', '.facets [type="checkbox"]', function() {
                if (this.checked) {
                    var facetValue = $('.facets [type="checkbox"]:checked').map(function() {
                        return this.name;
                    }).get();
                    fetchJson(true, facetValue);
                }
            });
        };
        facetsCheck();
        ///////////////////
    });
})(jQuery);