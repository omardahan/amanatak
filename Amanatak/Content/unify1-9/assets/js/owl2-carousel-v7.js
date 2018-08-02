var Owl2Carouselv7 = function () {
  return {
    // Owl Carousel v7
    initOwl2Carouselv7: function () {
      jQuery('.owl2-carousel-v7').owlCarousel( {
        loop: true,
        margin: 110,
        stagePadding: 80,
        smartSpeed: 750,
        navContainerClass: 'owl2-carousel-v7__btn',
        navClass: ['owl2-carousel-v7__btn-prev', 'owl2-carousel-v7__btn-next'],
        navText: ["<i class='fa fa-angle-left'></i>","<i class='fa fa-angle-right owl2-carousel-v7__btn-next__icon'></i>"],
        items: 1,
        nav: true,
      });
    }
  };
}();