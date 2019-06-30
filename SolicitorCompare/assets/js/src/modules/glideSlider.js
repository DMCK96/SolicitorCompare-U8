import Glide from '@glidejs/glide';

export default function initSlider() {
    const slider = document.getElementsByClassName('glide')[0];

    if(!slider) {
        return;
    }

    new Glide(slider).mount();
}

