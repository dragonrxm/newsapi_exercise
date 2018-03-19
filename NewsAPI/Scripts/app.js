var ViewModel = function () {
    var self = this;
    var numberOfNewsLoaded = 0;
    var takeNumberOfNews = 5;
    var maxNews = 15;
    self.news = ko.observableArray();
    self.error = ko.observable();

    var newsUri = '/api/news/';

    function ajaxHelper(uri, method) {
        self.error(''); // Clear error message
        return $.ajax({
            type: method,
            url: uri,
            dataType: 'json',
            contentType: 'application/json',
        }).fail(function (jqXHR, textStatus, errorThrown) {
            self.error(errorThrown);
        });
    }

    this.getNewsRange = function getNewsRange() {
        var uri = newsUri + "GetNewsRange?skip=" + numberOfNewsLoaded + "&take=" + takeNumberOfNews;
        ajaxHelper(uri, 'GET').done(function (data) {
            if (data) {
                ko.utils.arrayPushAll(self.news, data);
                numberOfNewsLoaded += takeNumberOfNews;
                if (numberOfNewsLoaded == maxNews) {
                    $("#loadBtn").prop( "disabled", true );
                }
            }
            
        });
    }

    self.detail = ko.observable();

    self.getNewsDetail = function (item) {
        var uri = newsUri + "GetNewsDetail?id=";
        ajaxHelper(uri + item.ID, 'GET').done(function (data) {
            self.detail(data);
        });
    }

    // Fetch the initial data.
    this.getNewsRange();
};

ko.applyBindings(new ViewModel());