$(function () {

    // DELETING ITEMS /////////////////////////////////////////
    $('#TodoList').on('click', 'li i', function () {
        var $li = $(this).parent();
        var id = $li.attr('data-id');

        eShop.todo.todo.delete(id).then(function () {
            $li.remove();
            abp.notify.info('Deleted the todo item.');
        });
    });

    // CREATING NEW ITEMS /////////////////////////////////////
    $('#NewItemForm').submit(function (e) {
        e.preventDefault();

        var todoText = $('#NewItemText').val();
        var addTodoItemDto = { text: todoText };
        eShop.todo.todo.create(addTodoItemDto).then(function (result) {
            $('<li data-id="' + result.id + '">')
                .html('<i class="fa fa-trash-o"></i> ' + result.text)
                .appendTo($('#TodoList'));
            $('#NewItemText').val('');
        });
    });


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