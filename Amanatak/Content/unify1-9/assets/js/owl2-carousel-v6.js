var Owl2Carouselv6 = function () {
  return {
    // Owl Carousel v6
    initOwl2Carouselv6: function () {
      jQuery('.owl2-carousel-v6').owlCarousel( {
        loop: true,
        margin: 0,
        responsive: {
          0: {
            items: 2,
          },
          500:{
            items: 3,
          },
          768:{
            items: 4,
          },
          1000:{
            items: 5,
          },
          1200:{
            items: 6,
          }
        },
        nav: false,
      });
    }
  };
}();