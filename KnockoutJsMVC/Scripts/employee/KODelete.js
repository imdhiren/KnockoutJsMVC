var parsedSelectedEmployee = $.parseJSON(selectedEmployee);

$(function () {
    ko.applyBindings(modelDelete);
});

var modelDelete = {
    Id: ko.observable(parsedSelectedEmployee.Id),
    Name: ko.observable(parsedSelectedEmployee.Name),
    PhoneNo: ko.observable(parsedSelectedEmployee.PhoneNo),
    Email: ko.observable(parsedSelectedEmployee.Email),
    deleteEmployee: function () {
        try {
            $.ajax({
                url: '/Employee/Delete',
                type: 'POST',
                dataType: 'json',
                data: ko.toJSON(this),
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