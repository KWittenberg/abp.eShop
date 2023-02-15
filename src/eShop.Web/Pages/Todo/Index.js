$(function () {

    var createModal = new abp.ModalManager(abp.appPath + 'Todo/AddtodoListModal');
    createModal.onResult(function () { dataTable.ajax.reload(); });

    var editModal = new abp.ModalManager(abp.appPath + 'Todo/UpdateTodoListModal');
    editModal.onResult(function () { dataTable.ajax.reload(); });


    $('#NewTodoListButton').click(function (e) { e.preventDefault(); createModal.open(); });





    // DELETING ITEMS /////////////////////////////////////////
    //$('#TodoList').on('click', 'li i', function () {
    //    var $li = $(this).parent();
    //    var id = $li.attr('data-id');

    //    eShop.todo.todo.delete(id).then(function () {
    //        $li.remove();
    //        abp.notify.info('Deleted the todo item.');
    //    });
    //});

    // NEW DELETING ITEMS with SweatAlert /////////////////////////////////////////
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
        })
            .then((result) => {
                if (result.isConfirmed) {
                    var btn = $(this);
                    var id = btn.data("id");
                    $('#leaveTypeId').val(id);
                    eShop.todo.todo.delete(id)
                        .then(function () { window.location.replace("/Todo"); });
                    //Swal.fire("Deleted!", "Your data has been deleted.", "success");
                }
            });
    });



    // CREATING NEW ITEMS /////////////////////////////////////
    //$('#NewItemForm').submit(function (e) {
    //    e.preventDefault();

    //    var todoText = $('#NewItemText').val();
    //    var addTodoItemDto = { text: todoText };
    //    eShop.todo.todo.create(addTodoItemDto).then(function (result) {
    //        $('<li data-id="' + result.id + '">')
    //            .html('<i class="fa fa-trash-o"></i> ' + result.text)
    //            .appendTo($('#TodoList'));
    //        $('#NewItemText').val('');
    //    });
    //});


    // CREATING NEW ITEMS only input text /////////////////////////////////////
    //$('#NewItemForm').submit(function (e) {
    //    e.preventDefault();

    //    var todoText = $('#NewItemText').val();
    //    eShop.todo.todo.create(todoText).then(function (result) {
    //        $('<li data-id="' + result.id + '">')
    //            .html('<i class="fa fa-trash-o"></i> ' + result.text)
    //            .appendTo($('#TodoList'));
    //        $('#NewItemText').val('');
    //    });
    //});
});