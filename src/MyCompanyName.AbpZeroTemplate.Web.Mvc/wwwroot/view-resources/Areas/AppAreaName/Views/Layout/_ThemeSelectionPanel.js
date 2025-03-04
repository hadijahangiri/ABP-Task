$(function () {
  var _uiCustomizationSettingsService = abp.services.app.uiCustomizationSettings;
  
  $('.theme-selection-link').click(function () {
    var theme = $(this)[0].dataset.bsTheme;

    _uiCustomizationSettingsService.changeThemeWithDefaultValues(theme).done(function () {
      window.location.reload();
    });
  });
});
