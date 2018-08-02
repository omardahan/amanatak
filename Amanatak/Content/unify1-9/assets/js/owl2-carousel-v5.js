var Owl2Carouselv5 = function () {
  return {
    // Owl Carousel v5
    initOwl2Carouselv5: function () {
      jQuery('.owl2-carousel-v5').owlCarousel( {
        loop: true,
        margin: 0,
        responsive: {
          0: {
            items: 5
          },
        },
        nav: false,
      });
    }
  };
}();