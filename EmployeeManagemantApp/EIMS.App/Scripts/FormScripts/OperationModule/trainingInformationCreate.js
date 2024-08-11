$(document).ready(function () {
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

            $.get("/api/GeneralInformations/TrainingInfoAutoComplete", { id: ui.item.value })
                .done(function (data) {
                    $("#GeneralInformationId").val(data.id);
                    $("#txtFindTrainee").val(data.employeId);
                    $("#SearchName").val(data.name);
                    $("#SearchPhoneNo").val(data.phoneNo);

                    loadDatatable(data.id);

                });

        }
    });

});

$(document.body).on("click", "#btnSubmit", function () {

    var vm = {};
    var id = $("#Id").val();
    vm.generalInformationId = $("#GeneralInformationId").val();
    vm.courseName = $("#CourseName").val();
    vm.result = $("#Result").val();
    vm.instituteName = $("#InstituteName").val();
    vm.institute = $("#Institute").val();
    vm.duration = $("#Duration").val();
    vm.year = $("#Year").val();
    vm.remark = $("#Remark").val();


    if (id == 0 || id == "" || id == null) {
        $.ajax({
            url: "/api/TrainingInformations",
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
            url: "/api/TrainingInformations/" + id,
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

    $("#TrainingInfoList").DataTable().destroy();

    $("#TrainingInfoList").DataTable({
        retrieve: true,
        paging: true,
        ajax: {
            url: "/api/TrainingInformations/GetTrainingInfo?id=" + id,
            dataSrc: ""
        },
        columns: [
            {
                data: "courseName"
            },
            {
                data: "result"
            },
            {
                data: "instituteName"
            },
            {
                data: "institute"
            },
            {
                data: "duration"
            },
            {
                data: "year"
            },
            {
                data: "id",
                render: function (data) {
                    return "<a class='btn btn-info btn-sm js-edit' data-id=" + data + " ><i class='fa fa-pencil-square fa-2x ' aria-hidden='false'></i></a>";
                }
            },
            {
                data: "id",
                render: function (data) {
                    return "<a class='btn-link js-delete'  data-id=" + data + "><i class='fa fa-trash fa-2x' aria-hidden='true' style='color: #d9534f;'></i></a>";
                }
            }
        ]
    });
}

function refreshForm() {
    $("#Id").val('');
    $("#CurseName").val('');
    $("#Result").val('');
    $("#InstituteName").val('');
    $("#Institute").val('');
    $("#Duration").val('');
    $("#Year").val('');
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
                    url: "/api/TrainingInformations/" + id,
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

$(document.body).on("click", ".js-edit", function () {
    refreshForm();
    var button = $(this);
    var id = button.attr("data-id");
    getData(id);


});

function getData(id) {
    $.get("/api/TrainingInformations?id=" + id)
        .done(function (data) {
            $("#Id").val(id);
            $("#GeneralInformationId").val(data.generalInformationId);
            $("#CurseName").val(data.curseName);
            $("#Result").val(data.result);
            $("#InstituteName").val(data.instituteName);
            $("#Institute").val(data.institute);
            $("#Duration").val(data.duration);
            $("#Year").val(data.year);
            $("#Remark").val(data.remark);

        });

}