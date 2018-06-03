$(function () {
    ko.applyBindings(modelCreate);
});

var modelCreate = {
    Name: ko.observable(),
    PhoneNo: ko.observable(),
    Email: ko.observable(),
    createEmployee: function () {
        try {
            $.ajax({
                url: '/Employee/Create',
                type: 'post',
                dataType: 'json',
                data: ko.toJSON(this), //Here the data wil be converted to JSON
                contentType: 'application/json',
                success: successCallback,
                error: errorCallback
            });
        } catch (e) {
            window.location.href = '/Employee/Read/';
        }
    }
};
function successCallback(data) {
    window.location.href = '/Employee/Read/';
}
function errorCallback(err) {
    window.location.href = '/Employee/Read/';
}