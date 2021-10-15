$(document).ready(function () {
    $(document).on("click", "#Product-Detail", function (e) {

        e.preventDefault();
        let url = $(this).attr("href");
        fetch(url).then(function (response) {
            return response.text();

        })
            .then(function (data) {

                $("#quickModal .product-details-modal").html(data)

            });
        $("#quickModal").modal("show")

    
        $.ajax({
            url:url,
            type: "GET",
            dataType:"json",
            success: function (response) {

                console.log(response);
            }

        })
        


    })


})

$(document).ready(function () {



    $(document).on("click", ".add-basket", function (e) {
        e.preventDefault();

        var id = $(this).attr("data-id");


        fetch('https://localhost:44342/book/AddToBasket/' + id)
            .then(response => response.text())
            .then(data => {


                $(".cart-block").html(data)
            });
    });

    $(document).on("click", ".delete", function (e) {
        e.preventDefault();

        var id = $(this).attr("data-id");

        console.log(id);

        fetch('https://localhost:44342/book/deletefrombasket/' + id)
            .then(response => response.text())
            .then(data => {

                console.log(data);
                $(".cart-block").html(data)
            });
    })


})