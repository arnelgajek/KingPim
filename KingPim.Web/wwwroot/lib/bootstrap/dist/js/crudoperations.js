$(document).ready(function () {

    // Allows the user to press Update and Delete when at least one checkbox i checked:
    var checkboxes = $("input[type='checkbox']"),
    submitButt = $("button[type='button']");

    checkboxes.click(function () {
        $('#createSomething').attr("disabled", checkboxes.is(":checked"));
        $('#updateSomething').attr("disabled", !checkboxes.is(":checked"));
        $('#deleteSomething').attr("disabled", !checkboxes.is(":checked"));
    });

    // PUBLISH:
    $('#publishchk').change(function () {
        cb = $(this);
        cb.val(cb.prop('checked'));

        if ($(this).is(':checked')) {
        // POST TO DB WITH AJAX (TRUE)
        console.log("JIHUUU");
        }
        else {
        // POST TO DB WITH AJAX (FALSE)
        console.log("BUHUUUU");
        }
    });

    // CREATE:
    $('#createSomething').click(function () {

        $('#createModal').on('show.bs.modal', function (event) {
            var modal = $(this);
            modal.find('.modal-body select');
        });
    });

    // UPDATE:
    $('#updateSomething').click(function () {
        getValueUsingClass();

        $('#updateModal').on('show.bs.modal', function (event) {
            var modal = $(this);
            var name = $(".table").find("input:checked").attr("data-name");
            modal.find('.modal-body p strong').text('You are about to update "' + name + '"');
        });
    });

    // DELETE:
    $('#deleteSomething').click(function () {
        getValueUsingClass();

        $('#deleteModal').on('show.bs.modal', function (event) {
            var modal = $(this);
            var name = $(".table").find("input:checked").attr("data-name");
            modal.find('.modal-body p strong').text('You are about to delete "' + name + '"');
        });
    });

    function getValueUsingClass() {

        // Declaring checkbox array:
        var chkArray = [];

        // Loop through all the classes with chk and see if they are checked:
        $('.chk:checked').each(function () {
        chkArray.push($(this).val());
        });

        // Join the array and separate the Ids with a comma:
        var selected;
        selected = chkArray.join(',');

        $('input[name="id"]').val(selected);
    }
});