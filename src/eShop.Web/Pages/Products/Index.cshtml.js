$(function () {
    var l = abp.localization.getResource('eShop');
    var dataTable = $('#Products').DataTable(
        abp.libs.datatables.normalizeConfiguration({
            serverSide: true,
            paging: true,
            order: [[0, "asc"]],
            searching: false,
            scrollX: true,
            ajax: abp.libs.datatables.createAjax(eShop.products.product.getList),
            columnDefs: [

                /* TODO: Column definitions */
                {
                    title: l('Image'),
                    data: "imageUrl",
                    width: "15%",
                    //render: function (data) {
                    //    return "<div style='text-align:center'><img src='" + data + "' alt='image'></div>";
                    //}
                    render: function (data) {
                        //return "<img src='" + data + "' alt='image' style='width:15%;'>";
                        return "<img src='" + data + "' alt='image'>";
                    }
                },
                {
                    title: l('Name'),
                    width: "25%",
                    render: function (data) {
                        return "<div style='text-align:center'>" + data + "</div>";
                    },
                    data: "name"
                },
                {
                    title: l('Categorys'),
                    render: function (data) {
                        return "<div style='text-align:center'>" + data + "</div>";
                    },
                    data: "categoryName",
                    orderable: false
                },
                {
                    title: l('Price'),
                    render: function (data) {
                        return "<div style='text-align:center'>" + data + "</div>";
                    },
                    data: "price"
                },
                {
                    title: l('StockState'),
                    data: "stockState",
                    render: function (data) {
                        //return l('Enum:StockState:' + data);
                        return l(data);
                    }
                },
                {
                    title: l('CreationTime'),
                    width: "15%",
                    data: "creationTime",
                    dataFormat: 'date'
                },
                {
                    title: l('Actions'),
                    rowAction: {
                        items:
                            [
                                {
                                    text: l('Edit'),
                                    action: function (data) {
                                        editModal.open({ id: data.record.id });
                                    }
                                },
                                {
                                    text: l('Delete'),
                                    confirmMessage: function (data) {
                                        return l('ProductDeletionConfirmationMessage',
                                            data.record.name);
                                    },
                                    action: function (data) {
                                        eShop.products.product.delete(data.record.id)
                                            .then(function () {
                                                abp.notify.info(l('SuccessfullyDeleted'));
                                                dataTable.ajax.reload();
                                            });
                                    }
                                }
                            ]
                    }
                },

            ],
            headerCallback: function (thead, data, start, end, display) {
                $(thead).find('th').css('text-align', 'center');
            },
        })
    );

    var createModal = new abp.ModalManager(abp.appPath + 'Products/AddProductModal');
    createModal.onResult(function () { dataTable.ajax.reload(); });

    var editModal = new abp.ModalManager(abp.appPath + 'Products/UpdateProductModal');
    editModal.onResult(function () { dataTable.ajax.reload(); });


    $('#NewProductButton').click(function (e) { e.preventDefault(); createModal.open(); });

});

$(function () {
    $('.deleteBtn').on('click', function (e) {
        e.preventDefault();
        var self = $(this);
        console.log(self.data('title'));
        Swal.fire({
            title: 'Are you sure ???',
            //text: "You won't be able to revert this!",
            icon: 'question',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Yes, delete it !'
        }).then((result) => {
            if (result.isConfirmed) {
                var btn = $(this);
                var id = btn.data("id");
                $('#leaveTypeId').val(id);
                eShop.products.product.delete(id)
                    //.then(function () {
                    //    abp.notify.info(l('SuccessfullyDeleted'));
                    //    dataTable.ajax.reload();
                    //    location.reload();
                    .then(function () {
                        window.location.replace("/Products");
                    });

                //$('#deleteForm').submit();
                //Swal.fire("Deleted!", "Your data has been deleted.", "success");
            }
        });
    });
});
