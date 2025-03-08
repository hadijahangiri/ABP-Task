(function ($) {
    //Custom validation type for tenancy name
    //$.validator.addMethod(
    //  'tenancyNameRegex',
    //  function (value, element, regexpr) {
    //    return regexpr.test(value);
    //  },
    //  app.localize('ProductName_Regex_Description')
    //  );

    app.modals.CreateProductModal = function () {
        var _productService = abp.services.app.product;
        //var _commonLookupService = abp.services.app.commonLookup;
        var _$productInformationForm = null;
        //var _passwordComplexityHelper = new app.PasswordComplexityHelper();

        var _modalManager;

        //var $selectedDateTime = {
        //    startDate: moment()
        //};

        this.init = function (modalManager) {
            _modalManager = modalManager;
            var modal = _modalManager.getModal();

            _$productInformationForm = modal.find('form[name=ProductInformationsForm]');
            //_$productInformationForm.validate({
            //  rules: {
            //    TenancyName: {
            //      tenancyNameRegex: new RegExp(_$productInformationForm.find('input[name=Name]').attr('regex')),
            //    },
            //  },
            //});

            //Show/Hide password inputs when "random password" checkbox is changed.

            //var passwordInputs = modal.find('input[name=AdminPassword],input[name=AdminPasswordRepeat]');
            //var passwordInputGroups = passwordInputs.closest('.product-admin-password');

            //_passwordComplexityHelper.setPasswordComplexityRules(passwordInputs, window.passwordComplexitySetting);

            //$('#CreateProduct_SetRandomPassword').change(function () {
            //  if ($(this).is(':checked')) {
            //    passwordInputGroups.slideUp('fast');
            //    passwordInputs.removeAttr('required');
            //  } else {
            //    passwordInputGroups.slideDown('fast');
            //    passwordInputs.attr('required', 'required');
            //  }
            //});

            //Show/Hide connection string input when "use host db" checkbox is changed.

            //var connStringInput = modal.find('input[name=ConnectionString]');
            //var connStringInputGroup = connStringInput.closest('.form-group');

            //$('#CreateProduct_UseHostDb').change(function () {
            //  if ($(this).is(':checked')) {
            //    connStringInputGroup.slideUp('fast');
            //    connStringInput.removeAttr('required');
            //  } else {
            //    connStringInputGroup.slideDown('fast');
            //    connStringInput.attr('required', 'required');
            //  }
            //});

            //modal.find('.date-time-picker').daterangepicker({
            //  singleDatePicker: true,
            //  timePicker: true,
            //  parentEl: '#CreateProductInformationsForm',
            //  startDate: moment().startOf('minute'),
            //  locale: {
            //      format: "L LT"
            //  },
            //}, (start) => $selectedDateTime.startDate = start);

            //var $subscriptionEndDateDiv = modal.find('input[name=SubscriptionEndDateUtc]').parent('div');
            //var $isUnlimitedInput = modal.find('#CreateProduct_IsUnlimited');
            //var subscriptionEndDateUtcInput = modal.find('input[name=SubscriptionEndDateUtc]');
            //function toggleSubscriptionEndDateDiv() {
            //  if ($isUnlimitedInput.is(':checked')) {
            //    $subscriptionEndDateDiv.slideUp('fast');
            //    subscriptionEndDateUtcInput.removeAttr('required');
            //  } else {
            //    $subscriptionEndDateDiv.slideDown('fast');
            //    subscriptionEndDateUtcInput.attr('required', 'required');
            //  }
            //}

            //var $isInTrialPeriodInputDiv = modal.find('#CreateProduct_IsInTrialPeriod').closest('div');
            //var $isInTrialPeriodInput = modal.find('#CreateProduct_IsInTrialPeriod');
            //function toggleIsInTrialPeriod() {
            //  if ($isUnlimitedInput.is(':checked')) {
            //    $isInTrialPeriodInputDiv.slideUp('fast');
            //    $isInTrialPeriodInput.prop('checked', false);
            //  } else {
            //    $isInTrialPeriodInputDiv.slideDown('fast');
            //  }
            //}

            //$isUnlimitedInput.change(function () {
            //  toggleSubscriptionEndDateDiv();
            //  toggleIsInTrialPeriod();
            //});

            //var $editionCombobox = modal.find('#EditionId');
            //$editionCombobox.change(function () {
            //  var isFree = $('option:selected', this).attr('data-isfree') === 'True';
            //  var selectedValue = $('option:selected', this).val();

            //  if (selectedValue === '' || isFree) {
            //    modal.find('.subscription-component').slideUp('fast');
            //    if (isFree) {
            //      $isUnlimitedInput.prop('checked', true);
            //    } else {
            //      $isUnlimitedInput.prop('checked', false);
            //    }
            //  } else {
            //    $isUnlimitedInput.prop('checked', false);
            //    toggleSubscriptionEndDateDiv();
            //    toggleIsInTrialPeriod();
            //    modal.find('.subscription-component').slideDown('fast');
            //  }
            //});

            //toggleSubscriptionEndDateDiv();
            //toggleIsInTrialPeriod();
            //$editionCombobox.trigger('change');

            //getDefaultEdition();
        };

        this.save = function () {
            if (!_$productInformationForm.valid()) {
                return;
            }
            var product = _$productInformationForm.serializeFormToObject();

            ////take selected date as UTC
            //if ($('#CreateProduct_IsUnlimited').is(':visible') && !$('#CreateProduct_IsUnlimited').is(':checked')) {
            //    product.SubscriptionEndDateUtc = $selectedDateTime.startDate.format('YYYY-MM-DDTHH:mm:ss') + 'Z';
            //} else {
            //  product.SubscriptionEndDateUtc = null;
            //}

            //if ($('#CreateProduct_IsUnlimited').is(':checked')) {
            //  product.IsInTrialPeriod = false;
            //}

            //if (product.SetRandomPassword) {
            //  product.Password = null;
            //  product.AdminPassword = null;
            //}

            //if (product.UseHostDb) {
            //  product.ConnectionString = null;
            //}

            _modalManager.setBusy(true);
            _productService
                .createProduct(product)
                .done(function () {
                    abp.notify.info(app.localize('SavedSuccessfully'));
                    _modalManager.close();
                    abp.event.trigger('app.createProductModalSaved');
                })
                .always(function () {
                    _modalManager.setBusy(false);
                });
        };

        //function getDefaultEdition() {
        //  _commonLookupService.getDefaultEditionName().done(function (defaultEdition) {
        //    var $editionCombobox = _modalManager.getModal().find('#EditionId');
        //    $editionCombobox.find('option').each(function () {
        //      if ($(this).text() == defaultEdition.name) {
        //        $(this).prop('selected', true).trigger('change');
        //      }
        //    });
        //  });
        //}
    };
})(jQuery);
