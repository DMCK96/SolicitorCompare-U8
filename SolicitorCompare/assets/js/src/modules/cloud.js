export default function initCloud() {
    if ($('.cloud').get(0)) {
        console.log('cloud');
        const moveCloud = function () {
            $('.cloud').animate({
                top: '+=20px'
            }, 3000, 'linear', function () {
                $('.cloud').animate({
                    top: '-=20px'
                }, 3000, 'linear', function () {
                    moveCloud();
                });
            });
        };
        moveCloud();
    }
}
