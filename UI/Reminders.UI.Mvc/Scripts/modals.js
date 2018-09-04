$(document).ready(function() {
    var today = new Date(new Date().getFullYear(), new Date().getMonth(), new Date().getDate());

    $("#reminder-add-button").on("click", function() {
        $("#reminder-add-modal").modal();
    });
    $("#reminder-add-modal").on("shown.bs.modal", function() {
        $("#create-textarea").focus();
    });
    $("#reminder-add-modal").on("hidden.bs.modal", function() {
        $("#create-textarea").val("");
    });
    $("#update-datepicker").datepicker({
        uiLibrary: "bootstrap4",
        header: true,
        minDate: today
    });
    $("#create-datepicker").datepicker({
        uiLibrary: "bootstrap4",
        header: true,
        minDate: today
    });
});

var HandleUpdate = function(reminder) {
    var id = reminder.Id;
    var text = reminder.Text;
    var priority = reminder.Priority;
    var dueDate = new Date(reminder.DueDate);

    $("#reminder-update-modal").modal();

    $("#update-id").val(id);
    $("#update-textarea").val(text);
    $("#update-priority option[value='" + priority + "']").prop("selected", true);
    if (reminder.DueDate !== null) {
        $("#update-datepicker").val((dueDate.getMonth() + 1) + "/" + dueDate.getDate() + "/" + dueDate.getFullYear());
    }
    $("#update-textarea").focus();
};