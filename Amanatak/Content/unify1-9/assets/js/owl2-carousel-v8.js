var Owl2Carouselv8 = function () {
  return {
    // Owl Carousel v8
    initOwl2Carouselv8: function () {
      jQuery('.owl2-carousel-v8').owlCarousel( {
        loop: true,
        margin: 20,
        responsive: {
          0: {
            items: 1,
          },
          500:{
            items: 2,
          },
          768:{
            items: 3,
          },
          1200:{
            items: 4,
          }
        },
        nav: false,
      });
    }
  };
}();