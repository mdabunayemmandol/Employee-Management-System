$(document).ready(function () {
    loadUniversity();
    loadSubject();
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
                    $("#GeneralInformationId").val(data.id);
                    $("#txtFindTrainee").val(data.employeId);
                    $("#SearchName").val(data.name);
                    $("#SearchPhoneNo").val(data.phoneNo);

                    loadDatatable(data.id);

                });

        }
    });

});

function loadUniversity() {
    $.get("/api/Universities", function (data) {
        var $el = $("#UniversityId");
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

function loadSubject() {
    $.get("/api/Subjects", function (data) {
        var $el = $("#SubjectId");
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
    vm.generalInformationId = $("#GeneralInformationId").val();
    vm.universityId = $("#UniversityId").val();
    vm.instituteName = $("#InstituteName").val();
    vm.subjectId = $("#SubjectId").val();
    vm.subjectName = $("#SubjectName").val();
    vm.result = $("#Result").val();
    vm.passingYear = $("#PassingYear").val();
    vm.duration = $("#Duration").val();
    vm.boardName = $("#BoardName").val();
    vm.remark = $("#Remark").val();


    if (id == 0 || id == "" || id == null) {
        $.ajax({
            url: "/api/EducationalInformations",
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
            url: "/api/EducationalInformations/" + id,
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

    $("#EducationList").DataTable().destroy();

    $("#EducationList").DataTable({
        retrieve: true,
        paging: true,
        ajax: {
            url: "/api/EducationalInformations/GetEducationInfo?id=" + id,
            dataSrc: ""
        },
        columns: [
            {
                data: "university.name"
            },
            {
                data: "subject.name"
            },
            {
                data: "subjectName"
            },
            {
                data: "result"
            },
            {
                data: "passingYear"
            },
            {
                data: "instituteName"
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
    $("#UniversityId").val('');
    $("#InstituteName").val('');
    $("#SubjectId").val('');
    $("#SubjectName").val('');
    $("#Result").val('');
    $("#PassingYear").val('');
    $("#Duration").val('');
    $("#BoardName").val('');
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
                    url: "/api/EducationalInformations/" + id,
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
    $.get("/api/EducationalInformations?id=" + id)
        .done(function (data) {
            $("#Id").val(id);
            $("#GeneralInformationId").val(data.generalInformationId);
            $("#UniversityId").val(data.universityId);
            $("#InstituteName").val(data.instituteName);
            $("#SubjectId").val(data.subjectId);
            $("#SubjectName").val(data.subjectName);
            $("#Result").val(data.result);
            $("#PassingYear").val(data.passingYear);
            $("#Duration").val(data.duration);
            $("#BoardName").val(data.boardName);
            $("#Remark").val(data.remark);

        });

}