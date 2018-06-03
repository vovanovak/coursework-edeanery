function getCheckedIds(idOfTable, checkBoxClassName) {
    var checkBoxes = $(idOfTable).find(checkBoxClassName);
    var ids = [];
    for (var i = 0; i < checkBoxes.length; i++) if (checkBoxes[i].checked) {
        var id = parseInt($(checkBoxes[i]).val());
        ids.push(id);
    }

    return ids;
}