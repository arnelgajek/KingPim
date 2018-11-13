$(document).ready(function () {

    var checkboxes = $(".chk");

    checkboxes.click(function () {
        $('#createSomething').prop("disabled", checkboxes.is(":checked"));
        $('#updateSomething').prop("disabled", !checkboxes.is(":checked"));
        $('#deleteSomething').prop("disabled", !checkboxes.is(":checked"));
    });

    // PUBLISH:
    $('.publishchk').click(function () {
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

        var url = "";
        //var entityType = "@ViewBag.EntityType";

        switch (entityType) {
            case "Category":
                url = "Category/Publish";
                break;
            case "SubCategory":
                url = "SubCategory/Publish";
                break;
            case "Product":
                url = "Product/Publish";
                break;
            default:
                break;
        }

        // Need to fix a if/else for the post depending if it is an category, product or attributegroup:
        $.ajax({
            type: 'POST',
            url: url,
            data: { id: id, published: trufal },
            dataType: 'JSON',
            success: function () {
                console.log("The value for publish has been changed and updated in the Db!");
            },
            error: function () {
                console.log("Whoops, something went wrong with the publish action...");
            }
        });
    });

    // CREATE:
    $('#createSomething').click(function () {
        $('#createModal').on('show.bs.modal', function () {
            var modal = $(this);
            modal.find('.modal-body select');
        });
    });

    // UPDATE:
    $('#updateSomething').click(function () {
        getValueUsingClass();

        $('#updateModal').on('show.bs.modal', function () {
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