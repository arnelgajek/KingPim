$(document).ready(function () {

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
        $('#createModal').modal('show');
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