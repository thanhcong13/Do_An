<template>
  <v-carousel style="position: relative" show-arrows="hover">
    <div style="width: 100%; height: 100%">
      <h1
        data-aos="fade-down"
        style="
          position: absolute;
          top: 38%;
          left: 28%;
          z-index: 10000;
          color: white;
          font-size: 50px;
          text-transform: uppercase;
        "
      >
        Thế giới xe 
      </h1>
      <v-carousel-item
        style="
          background: linear-gradient(
              rgba(64, 6, 97, 0.4),
              rgba(64, 6, 97, 0.4)
            ),
            url('../assets//images//Oto/1b79ceb7-20210607_034302.jpg')
              top center / cover no-repeat;
        "
      ></v-carousel-item>
    </div>

    <v-carousel-item
      src="https://preview.colorlib.com/theme/marian/assets/img/hero/h1_hero.jpg"
      cover
    ></v-carousel-item>

    <v-carousel-item
      src="https://preview.colorlib.com/theme/marian/assets/img/hero/h1_hero.jpg"
      cover
    ></v-carousel-item>
  </v-carousel>
</template>
