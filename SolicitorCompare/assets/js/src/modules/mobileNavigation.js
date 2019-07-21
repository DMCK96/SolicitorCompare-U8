export default function initMobileNavigation() {

  const mobileNavToggle = document.getElementsByClassName('mobile-navigation__toggle');
  const mobileMenu = document.getElementsByClassName('mobile-navigation');
  const mobileMenuToggles = document.getElementsByClassName('mobile-navigation__item__toggle');

  if(mobileNavToggle.length === 0) {
    return;
  }

  mobileNavToggle[0].addEventListener
  ('click', () => {
    if(mobileNavToggle[0].classList.contains('is-active'))
    {
      mobileNavToggle[0].classList.remove('is-active');
      mobileMenu[0].classList.remove('--show');
    }
    else
      {
        window.scrollTo(0,1);
      mobileNavToggle[0].classList.add('is-active');
        mobileMenu[0].classList.add('--show');
    }
  });

  Array.from(mobileMenuToggles).forEach(toggle => {
    toggle.addEventListener('click', () => {
      const index = toggle.getAttribute('data-index').valueOf();

      /* eslint-disable prefer-template */

      const subMenu = document.querySelectorAll('[data-submenuindex="' + index + '"]')[0];

      if (toggle.classList.contains('--open'))
      {
        toggle.classList.remove('--open');
        subMenu.classList.remove('--open');

      }
      else
      {
        toggle.classList.add('--open');
        subMenu.classList.add('--open');
      }
    });
  });
}
