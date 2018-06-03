var parsedSelectedEmployee = $.parseJSON(selectedEmployee);

$(function () {
    ko.applyBindings(modelUpdate);
});

var modelUpdate = {
    Id: ko.observable(parsedSelectedEmployee.Id),
    Name: ko.observable(parsedSelectedEmployee.Name),
    PhoneNo: ko.observable(parsedSelectedEmployee.PhoneNo),
    Email: ko.observable(parsedSelectedEmployee.Email),
    updateEmployee: function () {
        try {
            $.ajax({
                url: '/Employee/Update',
                type: 'POST',
                dataType: 'json',
                data: ko.toJSON(this),
                contentType: 'application/json',
                success: successCallback,
                error: errorCallback
            });
        } catch (e) {
            window.location.href = '/Home/Read/';
        }
    }
};
function successCallback(data) {
    window.location.href = '/Employee/Read/';
}
function errorCallback(err) {
    window.location.href = '/Employee/Read/';
}