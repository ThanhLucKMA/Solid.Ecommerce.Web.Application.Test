$(function () {
    new QRCode( //Tạo mới một mã QR
        $("#qrCode")[0], //Cung cấp placeholder nơi mà mã QR sẽ xuất hiện
        {
            text: $("#qrCodeData").data("url"), //Truy xuất URL được mã hoá trong QR từ phần tử
            width: 150,                         //html qrCodeData
            height: 150
        });
});