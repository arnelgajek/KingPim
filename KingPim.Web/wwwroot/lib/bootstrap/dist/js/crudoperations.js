$(document).ready(function () {

    var checkboxes = $(".chk");

    checkboxes.click(function () {
        $('#createSomething').prop("disabled", checkboxes.is(":checked"));
        $('#updateSomething').prop("disabled", !checkboxes.is(":checked"));
        $('#deleteSomething').prop("disabled", !checkboxes.is(":checked"));
    });

    // BG-COLOR PUBLISH:
    // TODO: Need to set red bg-color if publishvalue = false, green bg-color if publishvalue = true.

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
            },
            error: function () {
                console.log('NOOOO...');
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

    $("#addAttributeBtn").on("click", function () {
        $(".addAttribute").append(
            "<div class='form-group' id='addAttributeForm'>" 
            + "</br>"
            + "<div class='form-group'>"
            + "<input type='text' name='AttributeName' placeholder='Attribute Name...' class='form-control form-control-sm' /> </div>"
            + "<div class='form-group'>"
            + "<input type='text' name='Description' placeholder='Description...' class='form-control form-control-sm' /> </div>"
            + "<div class='form-group'>"
            + "<select class='form-control'>"
            + "<option value='' disabled selected>Select a type</option>"
            + "</br>"
            + "<option>Number</option>"
            + "<option>Text</option>"
            + "<option>Checkbox</option>"
            + "<option>Bool</option>"
            + "</select>"
            + "<button type='button' class='btn btn-success btn-sm' style='margin:5px'>Save</button>"
            + "<button type='button' class='btn btn-danger btn-sm' id='deleteAttrBtn'>Delete</button>"
            + "</div>"
        );

        $('#deleteAttrBtn').on("click", function () {
            $(this).closest('#addAttributeForm').remove();
            // After this function the user is not able to add a attribute again...
        })
    });
});