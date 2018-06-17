function deleteEntity(entityUrl) {
    $.ajax({
        url: entityUrl,
        type: "DELETE",
        success: function (data) {
            console.log("Ok");
        },
        error: function (response) {
            console.log(response);
        }
    });
}