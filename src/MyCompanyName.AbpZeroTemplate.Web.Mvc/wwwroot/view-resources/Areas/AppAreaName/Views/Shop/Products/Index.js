(function () {
    $(function () {
        var _categoryService = abp.services.app.product;
        var _$productsTable = $('#ProductsTable');
        var _$productsTableFilter = $('#ProductsTableFilter');
        var _$productsFormFilter = $('#ProductsFormFilter');
        //var _$subscriptionEndDateRangeActive = $('#ProductsTable_SubscriptionEndDateRangeActive');
        //var _$subscriptionEndDateRange = _$productsFormFilter.find("input[name='SubscriptionEndDateRange']");
        //var _$creationDateRangeActive = $('#ProductsTable_CreationDateRangeActive');
        //var _$creationDateRange = _$productsFormFilter.find("input[name='CreationDateRange']");
        var _$refreshButton = _$productsFormFilter.find("button[name='RefreshButton']");
        //var _$editionDropdown = _$productsFormFilter.find('#EditionDropdown');
        var _entityTypeFullName = 'MyCompanyName.AbpZeroTemplate.Shop.Products.Product';

        var _permissions = {
            create: abp.auth.hasPermission('Pages.Products.Create'),
            //edit: abp.auth.hasPermission('Pages.Products.Edit'),
            //changeFeatures: abp.auth.hasPermission('Pages.Products.ChangeFeatures'),
            //impersonation: abp.auth.hasPermission('Pages.Products.Impersonation'),
            //delete: abp.auth.hasPermission('Pages.Products.Delete'),
        };

        //var _urlParams = {
        //  creationDateStart: $.url('?creationDateStart'),
        //  creationDateEnd: $.url('?creationDateEnd'),
        //  subscriptionEndDateStart: $.url('?subscriptionEndDateStart'),
        //  subscriptionEndDateEnd: $.url('?subscriptionEndDateEnd'),
        //};

        //var _selectedSubscriptionEndDateRange = {
        //  startDate: _urlParams.subscriptionEndDateStart
        //    ? moment(_urlParams.subscriptionEndDateStart)
        //    : moment().startOf('day'),
        //  endDate: _urlParams.subscriptionEndDateEnd
        //    ? moment(_urlParams.subscriptionEndDateEnd)
        //    : moment().add(30, 'days').endOf('day'),
        //};

        //var _selectedCreationDateRange = {
        //  startDate: _urlParams.creationDateStart
        //    ? moment(_urlParams.creationDateStart)
        //    : moment().add(-7, 'days').startOf('day'),
        //  endDate: _urlParams.creationDateEnd ? moment(_urlParams.creationDateEnd) : moment().endOf('day'),
        //};

        //_$subscriptionEndDateRange.daterangepicker(
        //  $.extend(
        //    true,
        //    app.createDateRangePickerOptions({
        //      allowFutureDate: true,
        //    }),
        //    _selectedSubscriptionEndDateRange
        //  ),
        //  function (start, end, label) {
        //    _selectedSubscriptionEndDateRange.startDate = start;
        //    _selectedSubscriptionEndDateRange.endDate = end;
        //  }
        //);

        //_$creationDateRange.daterangepicker(
        //  $.extend(true, app.createDateRangePickerOptions(), _selectedCreationDateRange),
        //  function (start, end, label) {
        //    _selectedCreationDateRange.startDate = start;
        //    _selectedCreationDateRange.endDate = end;
        //  }
        //);

        var _createModal = new app.ModalManager({
            viewUrl: abp.appPath + 'AppAreaName/Products/CreateModal',
            scriptUrl: abp.appPath + 'view-resources/Areas/AppAreaName/Views/Shop/Products/_CreateModal.js',
            modalClass: 'CreateCategoryModal',
        });

        //var _editModal = new app.ModalManager({
        //  viewUrl: abp.appPath + 'AppAreaName/Products/EditModal',
        //  scriptUrl: abp.appPath + 'view-resources/Areas/AppAreaName/Views/Products/_EditModal.js',
        //  modalClass: 'EditCategoryModal',
        //});

        //var _featuresModal = new app.ModalManager({
        //  viewUrl: abp.appPath + 'AppAreaName/Products/FeaturesModal',
        //  scriptUrl: abp.appPath + 'view-resources/Areas/AppAreaName/Views/Products/_FeaturesModal.js',
        //  modalClass: 'CategoryFeaturesModal',
        //});

        //var _userLookupModal = app.modals.LookupModal.create({
        //  title: app.localize('SelectAUser'),
        //  serviceMethod: abp.services.app.commonLookup.findUsers,
        //});

        var _entityTypeHistoryModal = app.modals.EntityTypeHistoryModal.create();

        var getFilter = function () {
            //var editionId = _$editionDropdown.find(':selected').val();

            var filter = {
                filter: _$productsTableFilter.val(),
                //editionId: editionId,
                //editionIdSpecified: editionId !== '-1',
            };

            //if (_$creationDateRangeActive.prop('checked')) {
            //  filter.creationDateStart = _selectedCreationDateRange.startDate;
            //  filter.creationDateEnd = _selectedCreationDateRange.endDate;
            //}

            //if (_$subscriptionEndDateRangeActive.prop('checked')) {
            //  filter.subscriptionEndDateStart = _selectedSubscriptionEndDateRange.startDate;
            //  filter.subscriptionEndDateEnd = _selectedSubscriptionEndDateRange.endDate;
            //}

            return filter;
        };

        function entityHistoryIsEnabled() {
            return (
                abp.custom.EntityHistory &&
                abp.custom.EntityHistory.IsEnabled &&
                _.filter(abp.custom.EntityHistory.EnabledEntities, function (entityType) {
                    return entityType === _entityTypeFullName;
                }).length === 1
            );
        }

        var dataTable = _$productsTable.DataTable({
            paging: true,
            serverSide: true,
            processing: true,
            listAction: {
                ajaxFunction: _categoryService.getProducts,
                inputFilter: function () {
                    return getFilter();
                },
            },
            columnDefs: [
                {
                    className: 'dtr-control responsive',
                    orderable: false,
                    render: function () {
                        return '';
                    },
                    targets: 0,
                },
                {
                    targets: 1,
                    data: null,
                    orderable: false,
                    autoWidth: false,
                    defaultContent: '',
                    rowAction: {
                        text:
                            '<i class="fa fa-cog"></i> <span class="d-none d-md-inline-block d-lg-inline-block d-xl-inline-block">' +
                            app.localize('Actions') +
                            '</span> <span class="caret"></span>',
                        items: [
                            {
                                text: app.localize('LoginAsThisCategory'),
                                visible: function () {
                                    return _permissions.impersonation;
                                },
                                action: function (data) {
                                    _userLookupModal.open(
                                        {
                                            extraFilters: {
                                                categoryId: data.record.id,
                                            },
                                            title: app.localize('SelectAUser'),
                                        },
                                        function (selectedItem) {
                                            abp.ajax({
                                                url: abp.appPath + 'Account/ImpersonateCategory',
                                                data: JSON.stringify({
                                                    categoryId: data.record.id,
                                                    userId: parseInt(selectedItem.id),
                                                }),
                                                success: function () {
                                                    if (!app.supportsTenancyNameInUrl) {
                                                        abp.multiTenancy.setCategoryIdCookie(data.record.id);
                                                    }
                                                },
                                            });
                                        }
                                    );
                                },
                            },
                            {
                                text: app.localize('Edit'),
                                visible: function () {
                                    return _permissions.edit;
                                },
                                action: function (data) {
                                    _editModal.open({ id: data.record.id });
                                },
                            },
                            {
                                text: app.localize('Features'),
                                visible: function () {
                                    return _permissions.changeFeatures;
                                },
                                action: function (data) {
                                    _featuresModal.open({ id: data.record.id });
                                },
                            },
                            {
                                text: app.localize('Delete'),
                                visible: function () {
                                    return _permissions.delete;
                                },
                                action: function (data) {
                                    deleteCategory(data.record);
                                },
                            },
                            {
                                text: app.localize('Unlock'),
                                action: function (data) {
                                    _categoryService
                                        .unlockCategoryAdmin({
                                            id: data.record.id,
                                        })
                                        .done(function () {
                                            abp.notify.success(app.localize('UnlockedTenandAdmin', data.record.name));
                                        });
                                },
                            },
                            {
                                text: app.localize('History'),
                                visible: function () {
                                    return entityHistoryIsEnabled();
                                },
                                action: function (data) {
                                    _entityTypeHistoryModal.open({
                                        entityTypeFullName: _entityTypeFullName,
                                        entityId: data.record.id,
                                        entityTypeDescription: data.record.name,
                                    });
                                },
                            },
                        ],
                    },
                },
                {
                    targets: 2,
                    data: 'name',
                },
                {
                  targets: 3,
                  data: 'price',
                },
                //{
                //  targets: 4,
                //    data: 'discount',
                //},
                //{
                //  targets: 5,
                //  data: 'subscriptionEndDateUtc',
                //  render: function (subscriptionEndDateUtc) {
                //    if (subscriptionEndDateUtc) {
                //      return moment(subscriptionEndDateUtc).format('L');
                //    }

                //    return '';
                //  },
                //},
                //{
                //  targets: 6,
                //  data: 'isActive',
                //  render: function (isActive) {
                //    if (isActive) {
                //      return '<span class="badge badge-success">' + app.localize('Yes') + '</span>';
                //    } else {
                //      return '<span class="badge badge-dark">' + app.localize('No') + '</span>';
                //    }
                //  },
                //},
                {
                    targets: 4,
                    data: 'creationTime',
                    render: function (creationTime) {
                        return moment(creationTime).format('L');
                    },
                },
            ],
        });

        function getQueryStringParameter(name) {
            var uri = URI.parseQuery(document.location.href);
            return uri[name];
        }

        function getProducts() {
            dataTable.ajax.reload();
        }

        function deleteCategory(product) {
            abp.message.confirm(
                app.localize('CategoryDeleteWarningMessage', product.tenancyName),
                app.localize('AreYouSure'),
                function (isConfirmed) {
                    if (isConfirmed) {
                        _categoryService
                            .deleteCategory({
                                id: product.id,
                            })
                            .done(function () {
                                getProducts();
                                abp.notify.success(app.localize('SuccessfullyDeleted'));
                            });
                    }
                }
            );
        }

        $('#CreateNewCategoryButton').click(function () {
            _createModal.open();
        });

        $('#GetProductsButton').click(function (e) {
            e.preventDefault();
            getProducts();
        });

        abp.event.on('app.editCategoryModalSaved', function () {
            getProducts(true);
        });

        abp.event.on('app.createCategoryModalSaved', function () {
            getProducts(true);
        });

        //_$subscriptionEndDateRangeActive.change(function () {
        //    _$subscriptionEndDateRange.prop('disabled', !$(this).prop('checked'));
        //});

        //if (_urlParams.subscriptionEndDateStart || _urlParams.subscriptionEndDateEnd) {
        //    _$subscriptionEndDateRangeActive.prop('checked', true);
        //} else {
        //    _$subscriptionEndDateRange.prop('disabled', true);
        //}

        //_$creationDateRangeActive.change(function () {
        //    _$creationDateRange.prop('disabled', !$(this).prop('checked'));
        //});

        //if (_urlParams.creationDateStart || _urlParams.creationDateEnd) {
        //    _$creationDateRangeActive.prop('checked', true);
        //} else {
        //    _$creationDateRange.prop('disabled', true);
        //}
        _$refreshButton.click(function (e) {
            e.preventDefault();
            getProducts();
        });

        _$productsTableFilter.focus();
    });
})();
