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
                        return l('Enum:StockState:' + data);
                    }
                },
                {
                    title: l('CreationTime'),
                    width: "15%",
                    data: "creationTime",
                    dataFormat: 'date'
                },

            ],
            headerCallback: function (thead, data, start, end, display) {
                $(thead).find('th').css('text-align', 'center');
            },
        })
    );
});