$(document).ready(function () {
    GeneralEmployeId();
    loadDepartment();
    loadDesignation();
    //loadDatatable();
});


//bhuji nai---

$("#txtFindTrainee").autocomplete({
    source: function (request, response) {
        $.ajax({
            url: "/api/GeneralInformations/EmployeSearch",
            data: { query: request.term },
            type: "GET"
        }).done(function (data) {
            response($.map(data, function (item) {
                return { label: item.employeId + " " + item.name, value: item.id }
            }));
        });
    },
    minLength: 2,
    select: function (e, ui) {

        $.get("/api/GeneralInformations/EmployeInfoAutoComplete", { id: ui.item.value })
            .done(function (data) {
                $("#Id").val(data.id);
                $("#txtFindTrainee").val(data.employeId);
                $("#SearchName").val(data.name);
                $("#SearchPhoneNo").val(data.phoneNo);

                loadDatatable(data.id);

            });

    }
});


//bhuji nai---

function GeneralEmployeId() {
    $.get("/api/GeneralInformations/GetEmployeId",
        function (data) {
        $("#EmployeId").val(data);
    }); 
}

//Get Department
function loadDepartment() {
    $.get("/api/Departments", function (data) {
        var $el = $("#DepartmentId");
        $el.empty(); // remove old options
        $el.append($("<option></option>")
            .attr("value", '').text(''));
        $.each(data, function (value, key) {
            $el.append($('<option>',
                {
                    value: key.id,
                    text: key.name
                }));
        });
    });

}

//Get Designation
function loadDesignation() {
    $.get("/api/Designations", function (data) {
        var $el = $("#DesignationId");
        $el.empty(); // remove old options
        $el.append($("<option></option>")
            .attr("value", '').text(''));
        $.each(data, function (value, key) {
            $el.append($('<option>',
                {
                    value: key.id,
                    text: key.name
                }));
        });
    });

}

$(document.body).on("click", "#btnSubmit", function () {
    var vm = {};
    var id = $("#Id").val();
    vm.employeId = $("#EmployeId").val();
    vm.name = $("#Name").val();
    vm.fatherName = $("#FatherName").val();
    vm.motherName = $("#MotherName").val();
    vm.phoneNo = $("#PhoneNo").val();
    vm.email = $("#Email").val();
    vm.birthDate = $("#BirthDate").val();
    vm.presentAddress = $("#PresentAddress").val();
    vm.permanentAddress = $("#PermanentAddress").val();
    vm.nationalId = $("#NationalId").val();
    vm.nationality = $("#Nationality").val();
    vm.gender = $("#Gender").val();
    vm.bloodGroup = $("#BloodGroup").val();
    vm.religon = $("#Religon").val();
    vm.maritialStatus = $("#MaritialStatus").val();
    vm.jObJoiningDate = $("#JObJoiningDate").val();
    vm.salary = $("#Salary").val();
    vm.departmentId = $("#DepartmentId").val();
    vm.designationId = $("#DesignationId").val();
    vm.remark = $("#Remark").val();

    if ($("#IsActive:checked").val().length > 0) {
        vm.isActive = true;
    } else {
        vm.isActive = false;
    }

    if (id == 0 || id == "" || id == null) {
        $.ajax({
            url: "/api/GeneralInformations",
            data: vm,
            type: "POST",
            success: function (e) {
                if (e > 0) {
                    toastr.success("Save Success", "Success!!!");
                    loadDatatable(e);

                    refreshForm();

                } else {
                    toastr.warning("Save Fail", "Warning!!!");
                }
            },
            error: function (request, status, error) {
                var response = jQuery.parseJSON(request.responseText);
                toastr.error(response.message, "Error");
            }
        });
    }
    else {
        vm.id = id;

        $.ajax({
            url: "/api/GeneralInformations/" + id,
            data: vm,
            type: "PUT",
            success: function (e) {
                if (e > 0) {
                    toastr.success("Update Success", "Success!!!");
                    loadDatatable(e);

                    refreshForm();

                } else {
                    toastr.warning("Update Fail", "Warning!!!");
                }
            },
            error: function (request, status, error) {
                var response = jQuery.parseJSON(request.responseText);
                toastr.error(response.message, "Error");
            }
        });
    }
});

function loadDatatable(id) {
    $("#employeList").DataTable().destroy();
    $("#employeList").DataTable({
        retrieve: true,
        paging: true,
        ajax: {
            url: "/api/GeneralInformations/GetEmployeInfo?id=" + id,
            dataSrc: ""
        },
        columns: [
            {
                data: "employeId"
            },
            {
                data: "name"
            },
            {
                data: "department.name"
            },
            {
                data: "designation.name"
            },
            {
                data: "salary"
            },
            {
                data: "isActive",
                render: function (data) {
                    if (data) {
                        return "Active";
                    } else {
                        return "DeActive";
                    }
                }
            },
            {
                data: "id",
                render: function (data) {
                    return "<a class = 'btn btn-info btn-sm js-edit' data-id = " + data + "><i class ='fa fa-pencil-square fa-2x' aria-hidden='false'></i></a>";
                }
            },
            {
                data: "id",
                render: function (data) {
                    return "<a class='btn-link js-delete' data-id=" + data + "><i class='fa fa-trash fa-2x' aria-hidden='true' style='color:#d9534f;'></i></a>";
                }
            }
        ]
    });
}

$(document.body).on("click", ".js-edit", function () {
    refreshForm();
    var button = $(this);
    var id = button.attr("data-id");

    getData(id);
});

function getData(id) {
    $.get("/api/GeneralInformations?id=" + id)
        .done(function (data) {
            $("#Id").val(data.id);
            $("#EmployeId").val(data.employeId);
            $("#Name").val(data.name);
            $("#FatherName").val(data.fatherName);
            $("#MotherName").val(data.motherName);
            $("#PhoneNo").val(data.phoneNo);
            $("#Email").val(data.email);
            $("#BirthDate").val(data.birthDate);
            $("#PresentAddress").val(data.presentAddress);
            $("#PermanentAddress").val(data.permanentAddress);
            $("#NationalId").val(data.nationalId);
            $("#Nationality").val(data.nationality);
            $("#Gender").val(data.gender);
            $("#BloodGroup").val(data.bloodGroup);
            $("#Religon").val(data.religon);
            $("#MeritialStatus").val(data.meritialStatus);
            $("#JObJoiningDate").val(data.jObJoiningDate);
            $("#Salary").val(data.salary);
            $("#DepartmentId").val(data.departmentId);
            $("#DesignationId").val(data.designationId);
            $("#Remark").val(data.remark);

            if (data.isActive == 1) {
                $("#IsActive").prop('checked', true);
                $(".icheckbox_minimal-blue").addClass('checked').attr('aria-checked', 'true');
            }
            else {
                $("#IsActive").prop('checked', false);
                $(".icheckbox_minimal-blue").removeClass('checked').attr('aria-checked', 'false');
            }

        });
}

function refreshForm() {
    $("#Id").val('');
    $("#EmployeId").val('');
    $("#Name").val('');
    $("#FatherName").val('');
    $("#MotherName").val('');
    $("#PhoneNo").val('');
    $("#Email").val('');
    $("#BirthDate").val('');
    $("#PresentAddress").val('');
    $("#PermanentAddress").val('');
    $("#NationalId").val('');
    $("#Nationality").val('');
    $("#Gender").val('');
    $("#BloodGroup").val('');
    $("#Religon").val('');
    $("#MeritialStatus").val('');
    $("#JObJoiningDate").val('');
    $("#Salary").val('');
    $("#DepartmentId").val('');
    $("#DesignationId").val('');
    $("#Remark").val('');
    
}

$(document.body).on("click", "#btnRefresh", function () {
    refreshForm();
});

$(document.body).on("click", ".js-delete", function () {
    var button = $(this);
    var id = button.attr("data-id");
    bootbox.confirm("Are You Delete This Data?",
        function (result) {
            if (result) {
                $.ajax({
                    url: "/api/GeneralInformations/" + id,
                    method: "DELETE",
                    success: function () {
                        button.parents("tr").remove();
                        toastr.success("Delete Success");
                    },
                    error: function (request, status, error) {
                        var response = jQuery.parseJSON(request.responseText);
                        toastr.error(response.message, "Error");
                    }
                });
            }
        });
});