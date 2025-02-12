import initSlider from './glideSlider';
import initCloud from './cloud';
import initMobileNavigation from './mobileNavigation';
import initScrollTo from './anchorLinks';

const pageFunctions = {
    common: {
        init() {
            console.log('init');
            initSlider();
            initCloud();
            initMobileNavigation();
            initScrollTo();
        },

        finalize() {
            console.log('finalise');
        }
    }
};

const executePageFunctions = (finalize = false) => {
    const body = document.body;

    if (finalize) {
        pageFunctions.common.finalize();
    }

    else {
        pageFunctions.common.init();
    }
    for (let bodyClass of body.classList) {
        bodyClass = bodyClass.replace(/-/g, '_');
        if (finalize) {
            if (typeof pageFunctions[bodyClass] !== 'undefined') {
                if (typeof pageFunctions[bodyClass].finalize !== 'undefined') {
                    pageFunctions[bodyClass].finalize();
                }
            }
        }
        else {
            if (typeof pageFunctions[bodyClass] !== 'undefined') {
                if (typeof pageFunctions[bodyClass].init !== 'undefined') {
                    pageFunctions[bodyClass].init();
                }
            }
        }
    }
};

document.addEventListener('DOMContentLoaded', function () {
    executePageFunctions(true);
});

executePageFunctions();
