var selectedId = "00000000-0000-0000-0000-000000000000";
$(function() {
    $("#btnAdd").click(function() { add(); });
    $("#btnSave").click(function() { save(); });
    $("#btnDelete").click(function() { deleteMulti(); });
    $("#checkAll").click(function() { checkAll(this) });
    loadTables(1);
});

function checkAll(obj) {
    $(".checkBoxes").each(function() {
        if (obj.checked === true) {
            $(this).prop("checked", true);

        } else if (obj.checked === false) {
            $(this).prop("checked", false);
        }
    });
};

function loadTables(startPage) {
    $("#tableBody").html("");
    $("#checkAll").prop("checked", false);
    $.ajax({
        type: "GET",
        url: "/Tag/List?page=" + startPage,
        success: function(data) {
            $.each(data.datas,
                function(i, item) {
                    var tr = "<tr>";
                    tr += "<td align='center'><input type='checkbox' class='checkBoxes' value='" + item.id + "'/></td>";
                    tr += "<td>" + item.name + "</td>";
                    tr += "<td>" + (item.description == null ? "" : item.description) + "</td>";
                    tr += "<td>";
                    tr += "<button class='btn btn-info btn-xs' href='javascript:;' onclick='edit(\"" +
                        item.id +
                        "\")'><i class='fa fa-edit'></i> Edit </button>";
                    tr += "<button class='btn btn-danger btn-xs' href='javascript:;' onclick='deleteSingle(\"" +
                        item.id +
                        "\")'><i class='fas fa-trash'></i> Delete </button>";
                    tr += "</td>";
                    tr += "</tr>";
                    $("#tableBody").append(tr);
                });

            if (data.pageCount > 1) {
                $("#ulPagingPart").html("");
                var page = "";
                for (var i = 1; i <= data.pageCount; i++) {
                    page += "<li class='" + (startPage === i ? "page-item active" : "page-item") + "'>";
                    page += "<button class='page-link' onclick='loadTables(" + i + ")'>" + i + "</button>";
                    page += "</li>";
                }
                $("#ulPagingPart").append(page);
            }
        }
    });
};

function add() {
    $("#ID").val(0);
    $("#Name").val("");
    $("#Description").val("");
    $("#Title").text("New Tag");
    $("#editModal").modal("show");
};

function edit(id) {
    $.ajax({
        type: "Get",
        url: "/Tag/Get?id=" + id,
        success: function(data) {
            $("#ID").val(data.id);
            $("#Name").val(data.name);
            $("#Description").val(data.description);
            $("#Title").text("Edit User");
            $("#editModal").modal("show");
        }
    });
};

function save() {
    var postData = {
        "ID": $("#ID").val(),
        "Name": $("#Name").val(),
        "Description": $("#Description").val()
    };
    $.ajax({
        type: "Post",
        url: "/Tag/Save",
        data: postData,
        success: function(data) {
            if (data.code === 200) {
                loadTables(1);
                $("#editModal").modal("hide");
            } else {
                layer.tips(data.message, "#btnSave");
            };
        }
    });
};

function deleteMulti() {
    var ids = "";
    $(".checkboxs").each(function() {
        if ($(this).prop("checked") == true) {
            ids += $(this).val() + ",";
        }
    });
    ids = ids.substring(0, ids.length - 1);
    if (ids.length == 0) {
        layer.alert("Please select a record to delete.");
        return;
    };

    layer.confirm("Are you sure to delete the selected record?",
        {
            btn: ["Yes", "Cancel"]
        },
        function() {
            var sendData = { "ids": ids };
            $.ajax({
                type: "Post",
                url: "/Tag/DeleteMuti",
                data: sendData,
                success: function(data) {
                    if (data.code === 200) {
                        loadTables(1);
                        layer.closeAll();
                    } else {
                        layer.alert(data.message);
                    }
                }
            });
        });
};

function deleteSingle(id) {
    layer.confirm("Are you sure to delete the selected record?",
        {
            btn: ["Yes", "Cancel"]
        },
        function() {
            $.ajax({
                type: "POST",
                url: "/Tag/Delete",
                data: { "id": id },
                success: function(data) {
                    if (data.code === 200) {
                        loadTables(1);
                        layer.closeAll();
                    } else {
                        layer.alert(data.message);
                    }
                }
            });
        });
};