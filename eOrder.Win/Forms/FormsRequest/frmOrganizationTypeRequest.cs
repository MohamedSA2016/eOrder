﻿using eOrder.CORE.Requests;
using eOrder.Win.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eOrder.Win.Forms.FormsRequest
{
    public partial class frmOrganizationTypeRequest : Form
    {
        APIService _organizationTypeAPIService = new APIService("OrganizationType");
        private int? _id;

        public frmOrganizationTypeRequest(int? id = null)
        {
            InitializeComponent();
            _id = id;
        }

        private async void frmOrganizationTypeRequest_Load(object sender, EventArgs e)
        {
            if (_id.HasValue)
            {
                var model = await _organizationTypeAPIService.GetById<OrganizationTypeDTO>(_id.Value);
                ControlsHelper.MapPropsToControls(model, gbxOrganizationTypeData);
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            var request = ControlsHelper.MapControlsToProps(new OrganizationTypeRequest(), gbxOrganizationTypeData);

            if (_id.HasValue)
            {
                await _organizationTypeAPIService.Update<OrganizationTypeDTO>(_id.Value, request);
            }
            else
            {
                await _organizationTypeAPIService.Insert<OrganizationTypeDTO>(request);
            }

            Hide();
        }

        private void gbxOrganizationTypeData_Enter(object sender, EventArgs e)
        {

        }
    }
}
