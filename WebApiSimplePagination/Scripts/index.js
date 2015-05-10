/// <reference path="knockout-3.3.0.js" />


var searchService = {
    serviceUrl: "/api/customer/",
    getCustomers: function(data) {
        var options = {
            type: "GET",
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            url: this.serviceUrl,
            data: data
        };
    return $.ajax(options);
    }
}

var customersViewModel = {
    totalPages: ko.observable(),
    currentPage: ko.observable(0),
    listPages: ko.observableArray(),
    totalCustomers: ko.observable(),
    customerList: ko.observableArray(),
    search: function () {
        var data = {
            page: this.currentPage()
        };
        searchService.getCustomers(data)
            .success(function (response) {
                console.log(response);
                if (response.Results.length > 0) {
                    customersViewModel.customerList(response.Results);
                    customersViewModel.totalCustomers(response.TotalRows);
                    customersViewModel.listPages.removeAll();
                    for (var i = 1; i <= response.TotalPages; i++) {
                        customersViewModel.listPages.push(i);
                    }
                }
            })
            .fail(function() {
                alert('Error');
            }
        );
    },
    changePage: function (page) {
        customersViewModel.currentPage(page - 1);
        customersViewModel.search();
    }
}

ko.applyBindings(customersViewModel);