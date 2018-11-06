$(document).ready(function () {

    // Allows the user to press Update and Delete when at least one checkbox i checked:
    var checkboxes = $(".chk");

    checkboxes.click(function () {
        $('#createSomething').prop("disabled", checkboxes.is(":checked"));
        $('#updateSomething').prop("disabled", !checkboxes.is(":checked"));
        $('#deleteSomething').prop("disabled", !checkboxes.is(":checked"));
    });

    // PUBLISH:
    
    $('#publishchk').click(function () {
        cb = $(this);
        cb.val(cb.prop('checked'));
        
        if ($(this).is(':checked')) {
            var trufal = $(this).prop('value');
            var id = $(this).attr('data-name');
        }
        else {
            var trufal = $(this).prop('value');
            var id = $(this).attr('data-name');
        }

        $.ajax({
            type: 'POST',
            url: 'Category/Publish',
            data: { id: id, published: trufal },
            dataType: 'JSON',
            success: function () {
                console.log('JIPPIEEE!!!');
                //location.reload();
            },
            error: function () {
                console.log('NOOOO...');
            }
        });

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