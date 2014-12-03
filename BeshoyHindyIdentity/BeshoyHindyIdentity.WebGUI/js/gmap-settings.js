function initialize() {
    var e = new google.maps.LatLng(30.0877972, 31.2031565);
    var t = [{
        featureType: "landscape", elementType: "geometry.fill",
        stylers: [{ color: "#474D5D" }]
    },
    {
        elementType: "labels.text.fill",
        stylers: [{ color: "#FFFFFF" }]
    },
    {
        elementType: "labels.text.stroke",
        stylers: [{ visibility: "off" }]
    },
    {
        featureType: "road",
        elementType: "geometry.fill",
        stylers: [{ color: "#50525f" }]
    },
    {
        featureType: "road",
        elementType: "geometry.stroke",
        stylers: [{ visibility: "on" },
            { color: "#808080" }]
    },
    {
        featureType: "poi",
        elementType: "labels",
        stylers: [{ visibility: "off" }]
    },
    {
        featureType: "transit",
        elementType: "labels.icon", stylers: [{ visibility: "off" }]
    },
    {
        featureType: "poi",
        elementType: "geometry", stylers: [{ color: "#808080" }]
    },
    {
        featureType: "water",
        elementType: "geometry.fill", stylers: [{ color: "#3071a7" }, { saturation: -65 }]
    },
    {
        featureType: "road",
        elementType: "labels.icon",
        stylers: [{ visibility: "off" }]
    },
    {
        featureType: "landscape",
        elementType: "geometry.stroke",
        stylers: [{ color: "#bbbbbb" }]
    }];
    var n = {
        zoom: 14, center: e,
        disableDefaultUI: true,
        scrollwheel: false,
        navigationControl: false,
        mapTypeControl: false,
        scaleControl: false,
        draggable: false,
        mapTypeControlOptions: { mapTypeIds: [google.maps.MapTypeId.ROADMAP, "roadatlas"] }
    }; var r = new google.maps.Map(document.getElementById("map_canvas"), n);
    var i = new google.maps.Marker({ position: e, map: r, icon: "img/location-icon.png", title: "" });
    var s = '<div style="max-width: 300px" id="content">' + '<div id="bodyContent">' + "<h4>Beshoy Hindy</h4>" + '<p style="font-size: 12px">this is my home </br> 11 Galal Mousa St., El-Monerah El-Gharbiah - Embabah , Cairo , Egypt.</p>' + "</div>" + "</div>";
    var o = new google.maps.InfoWindow({ content: s }); google.maps.event.addListener(i, "click", function () { o.open(r, i) });
    var u = { name: "US Road Atlas" };
    var a = new google.maps.StyledMapType(t, u); r.mapTypes.set("roadatlas", a);
    r.setMapTypeId("roadatlas")
} google.maps.event.addDomListener(window, "load", initialize)