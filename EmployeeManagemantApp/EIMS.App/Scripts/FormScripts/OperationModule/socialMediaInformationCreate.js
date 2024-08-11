﻿$(document).ready(function () {
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

            $.get("/api/GeneralInformations/SocialMediaInfoAutoComplete", { id: ui.item.value })
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
    vm.profileName = $("#ProfileName").val();
    vm.profileLink = $("#ProfileLink").val();
    vm.remark = $("#Remark").val();


    if (id == 0 || id == "" || id == null) {
        $.ajax({
            url: "/api/SocialMediaInformations",
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
            url: "/api/SocialMediaInformations/" + id,
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

    $("#SocialInfoList").DataTable().destroy();

    $("#SocialInfoList").DataTable({
        retrieve: true,
        paging: true,
        ajax: {
            url: "/api/SocialMediaInformations/GetSocialMediaInfo?id=" + id,
            dataSrc: ""
        },
        columns: [
            {
                data: "profileName"
            },
            {
                data: "profileLink"
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
    $("#ProfileName").val('');
    $("#ProfileLink").val('');
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
                    url: "/api/SocialMediaInformations/" + id,
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
    $.get("/api/SocialMediaInformations?id=" + id)
        .done(function (data) {
            $("#Id").val(id);
            $("#GeneralInformationId").val(data.generalInformationId);
            $("#ProfileName").val(data.profileName);
            $("#ProfileLink").val(data.profileLink);
            $("#Remark").val(data.remark);

        });

}