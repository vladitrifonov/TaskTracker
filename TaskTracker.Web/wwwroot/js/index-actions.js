$(document).ready(function () {

    $('.btn-edit').click(function () {
        var btn = $(this);
        $('#modal-title').text(btn.data('title'));
        $('#modal-body').text('Loading...');
        $('#edit-modal').modal({});
        $('#modal-body').load(btn.data('url'));
    });

    $('.btn-delete').click(function () {
        var btn = $(this);
        confirm(function () {
            $.post(btn.data('url'))
                .done(function (data) {
                    if (data.succeeded) {
                        btn.closest('tr').remove();
                        alertSuccess(btn.data('title') + ' has been deleted');
                    }
                    else {
                        alertDanger(data.message);
                    }
                })
                .fail(function () {
                    alertDanger('Delete failed');
                })
        },
            btn.data('title') + ' will be deleted. Are you sure?',
            'Delete confirmation');
    });

    $('.btn-save').click(function () {
        var btn = $(this);
        confirm(function () {
            $.post(btn.data('url'))
                .done(function (data) {
                    if (data.succeeded) {
                        btn.closest('tr').remove();
                        alertSuccess(btn.data('title') + ' has been updated');
                    }
                    else {
                        alertDanger(data.message);
                    }
                })
                .fail(function () {
                    alertDanger('Delete failed');
                })
        },
            btn.data('title') + ' will be updated. Are you sure?',
            'Update confirmation');
    });

    $('#apply-button').click(function () {
        var form = $('#edit-form');       
        $.post(form.attr('action'), form.serialize())
            .done(function (data) {
                if (data.succeeded) {
                   /* $('#edit-modal').modal('hide');*/
                    window.location.reload();
                } else {
                    $('#modal-body').html(data);
                }
            })
            .fail(function () {
                alert('Update failed');
            });     
    });
});