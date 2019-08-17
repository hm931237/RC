using System.Web;
using System.Web.Optimization;

namespace RC
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/Scripts/jquery-1.10.2.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/admin-lte/lib").Include(
              //  "~/Content/bower_components/jquery/dist/jquery.min.js",
              //  "~/Content/bower_components/bootstrap/dist/js/bootstrap.min.js",
                "~/Content/bower_components/jquery-slimscroll/jquery.slimscroll.min.js",
                "~/Content/bower_components/fastclick/lib/fastclick.js",
                "~/Content/dist/js/adminlte.min.js",
                "~/Content/plugins/jstars/jstars.js",
                "~/Content/3D Fold out/js/index.js",
                "~/Content/bower_components/select2/dist/js/select2.full.min.js",
                "~/Content/plugins/input-mask/jquery.inputmask.js",
                "~/Content/plugins/input-mask/jquery.inputmask.date.extensions.js",
                "~/Content/plugins/input-mask/jquery.inputmask.extensions.js",
                "~/Content/bower_components/moment/min/moment.min.js",
                "~/Content/bower_components/bootstrap-daterangepicker/daterangepicker.js",
                "~/Content/bower_components/bootstrap-datepicker/dist/js/bootstrap-datepicker.min.js",
                "~/Content/bower_components/bootstrap-colorpicker/dist/js/bootstrap-colorpicker.min.js",
                "~/Content/plugins/timepicker/bootstrap-timepicker.min.js",
                "~/Content/plugins/iCheck/icheck.min.js",
                "~/Content/comparison/js/main.js",
                "~/Scripts/DataTables/jquery.dataTables.js",
                "~/Scripts/DataTables/dataTables.bootstrap.js",
                "~/Content/comparison/js/main.js",
                "~/Content/starRate/js/star-rating.js",
                "~/Scripts/toastr.js",
                "~/Scripts/typeahead.bundle.js"
              
                ));
            bundles.Add(new ScriptBundle("~/admin-bootstrap/js").Include(
                  "~/Content/bower_components/bootstrap/dist/js/bootstrap.min.js"
            ));
            bundles.Add(new ScriptBundle("~/admin-lte/lib").Include(
             //   "~/Content/bower_components/jquery/dist/jquery.min.js",
                //"~/Content/bower_components/bootstrap/dist/js/bootstrap.min.js",
                "~/Content/bower_components/jquery-slimscroll/jquery.slimscroll.min.js",
                "~/Content/bower_components/fastclick/lib/fastclick.js",
                "~/Content/dist/js/adminlte.min.js",
                "~/Content/plugins/jstars/jstars.js",
                "~/Content/3D Fold out/js/index.js",
                "~/Content/bower_components/select2/dist/js/select2.full.min.js",
                "~/Content/plugins/input-mask/jquery.inputmask.js",
                "~/Content/plugins/input-mask/jquery.inputmask.date.extensions.js",
                "~/Content/plugins/input-mask/jquery.inputmask.extensions.js",
                "~/Content/bower_components/moment/min/moment.min.js",
                "~/Content/bower_components/bootstrap-daterangepicker/daterangepicker.js",
                "~/Content/bower_components/bootstrap-datepicker/dist/js/bootstrap-datepicker.min.js",
                "~/Content/bower_components/bootstrap-colorpicker/dist/js/bootstrap-colorpicker.min.js",
                "~/Content/plugins/timepicker/bootstrap-timepicker.min.js",
                "~/Content/plugins/iCheck/icheck.min.js",
                "~/Content/comparison/js/main.js",
                "~/Scripts/DataTables/jquery.dataTables.js",
                "~/Scripts/DataTables/dataTables.bootstrap.js",
                "~/Content/comparison/js/main.js",
                "~/Content/starRate/js/star-rating.js",
                "~/Scripts/toastr.js",
                "~/Scripts/typeahead.bundle.js"

                ));

            bundles.Add(new ScriptBundle("~/admin-lte/bootbox").Include(
        "~/Scripts/bootbox.js"

        ));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js",
                      "~/Scripts/gulpfile.js",
                      "~/Scripts/jstars.js",
                      "~/Scripts/jstars.min.js",
                      "~/Scripts/Chart.js",
                      "~/Scripts/Chart.min.js",
                 "~/Scripts/jquery.validate.js"
                      ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));


            bundles.Add(new ScriptBundle("~/bundles/toastr").Include(
                      "~/Scripts/toastr.js*",
                      "~/Scripts/toastrImp.js"));

            bundles.Add(new StyleBundle("~/organziationlayout/lib").Include(
               "~/Content/organizationHomePage.css",
                "~/Content/bootstrapValidator.css"

               ));
            bundles.Add(new StyleBundle("~/RateStar/css").Include(
                "~/Content/bower_components/bootstrap/dist/css/bootstrap.min.css",
               "~/Content/starRate/css/star-rating.css",
                "~/Content/typeahead.css"
           ));
            bundles.Add(new ScriptBundle("~/RateStar/js").Include(
                            "~/Content/starRate/js/star-rating.js",
                "~/Scripts/typeahead.bundle.js"
                        ));
            bundles.Add(new StyleBundle("~/admin-lte/css").Include(
                "~/Content/dist/css/AdminLTE.min.css",
                "~/Content/bower_components/bootstrap/dist/css/bootstrap.min.css",
                "~/Content/bower_components/font-awesome/css/font-awesome.min.css",
                "~/Content/bower_components/Ionicons/css/ionicons.min.css",
                "~/Content/dist/css/AdminLTE.css",
                "~/Content/dist/css/skins/_all-skins.min.css",
                "~/Content/3D Fold out/css/style.css",
                "~/Content/bootstrap.min.css",
                "~/Content/font-awesome/css/all.css",
                "~/Content/font-awesome/css/fontawesome.css",
                "~/Content/bower_components/bootstrap-daterangepicker/daterangepicker.css",
                "~/Content/bower_components/bootstrap-datepicker/dist/css/bootstrap-datepicker.min.css",
                "~/Content/plugins/iCheck/all.css",
                "~/Content/bower_components/bootstrap-colorpicker/dist/css/bootstrap-colorpicker.min.css",
                "~/Content/plugins/timepicker/bootstrap-timepicker.min.css",
                "~/Content/bower_components/select2/dist/css/select2.min.css",
                "~/Content/comparison/css/reset.css",
                "~/Content/comparison/css/style.css",
                "~/Content/toastr.css",
                "~/Content/comparison/css/reset.css",
                "~/Content/comparison/css/style.css",
                "~/Content/starRate/css/star-rating.css",
                "~/Content/typeahead.css"




                ));



           
        }
    }
}
