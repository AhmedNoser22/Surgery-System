$(document).ready(function () {
    $(".delete-icon").on("click", function () {
        var id = $(this).data("id");
        var row = $(this).closest("tr");

        Swal.fire({
            title: "Are you sure?",
            text: "This surgery will be deleted permanently.",
            icon: "warning",
            showCancelButton: true,
            confirmButtonColor: "#d33",
            cancelButtonColor: "#3085d6",
            confirmButtonText: "Yes, delete it!"
        }).then((result) => {
            if (result.isConfirmed) {
                $.ajax({
                    url: '/Surgery/Delete?id=' + id,
                    type: 'DELETE',
                    success: function (res) {
                        Swal.fire({
                            icon: "success",
                            title: "Deleted!",
                            text: res.message,
                            timer: 1500,
                            showConfirmButton: false
                        });
                        row.fadeOut(500, function () {
                            $(this).remove();
                        });
                    },
                    error: function (xhr) {
                        let errMsg = "Something went wrong.";
                        if (xhr.responseJSON && xhr.responseJSON.message) {
                            errMsg = xhr.responseJSON.message;
                        }
                        Swal.fire({
                            icon: "error",
                            title: "Error",
                            text: errMsg
                        });
                    }
                });
            }
        });
    });
});
