using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using Grasshopper;
using Grasshopper.Kernel;
using Grasshopper.Kernel.Types;
using Grasshopper.GUI;
using Grasshopper.GUI.Canvas;
using System.Drawing;
using Rhino;
using System.Net;
using System.IO;
using Grasshopper.Kernel.Data;
using Rhino.Geometry;
using System.Runtime.InteropServices;


namespace PointGenerator
{
    internal static class UnsafeNativeMethods
    {
        const string _dllLocation = "LowDiscBlueNoise.dll";
        [DllImport(_dllLocation)]
        public static extern void initSamplers();

        [DllImport(_dllLocation)]
        public static extern int ldbnBNOT(int samples);

        [DllImport(_dllLocation)]
        public static extern IntPtr getPointAt(int i);

        [DllImport(_dllLocation)]
        public static extern void clearSamplers();
    }

    public class Populate2D : GH_Component
    {

        public Populate2D()
            : base("Blue Noise Populate 2D", "Blue Noise 2D", "Populate a 2-Dimensional region with points using a low discrepancy blue noise sampling algorithm. For more information visit: https://projet.liris.cnrs.fr/ldbn/", "Vector", "Grid")
        {

        }

        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddIntegerParameter("Approximate Number of Points", "N", "Approximate Number of Points", GH_ParamAccess.item, 200);
            pManager.AddIntervalParameter("Domain", "X", "Domain of the X-axis of the point field", GH_ParamAccess.item, new Interval(0.0, 1.0));
            pManager.AddIntervalParameter("Domain", "Y", "Domain of the Y-axis of the point field", GH_ParamAccess.item, new Interval(0.0, 1.0));
        }

        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddPointParameter("Points", "P", "Points", GH_ParamAccess.list);
        }

        public static void InitSamplers()
        {
            UnsafeNativeMethods.initSamplers();
        }

        public static void ClearSamplers()
        {
            UnsafeNativeMethods.clearSamplers();
        }

        public static int GeneratePts(int samples)
        {
            return UnsafeNativeMethods.ldbnBNOT(samples);
        }

        public static Point3d getPointAt(int i)
        {
            IntPtr ptr = UnsafeNativeMethods.getPointAt(i);
            double[] pt = new double[2];
            Marshal.Copy(ptr, pt, 0, 2);
            if (pt.Length < 0) pt = new double[2] { 0.0, 0.0 };
            return new Point3d(pt[0], pt[1], 0.0);
        }

        public override void RemovedFromDocument(GH_Document document)
        {
            ClearSamplers();
            base.RemovedFromDocument(document);
        }

        protected override void SolveInstance(IGH_DataAccess DA)
        {
            int samples = 200;
            Interval mi_x = new Interval();
            Interval mi_y = new Interval();

            if (
                    DA.GetData<int>(0, ref samples) &&
                    DA.GetData<Interval>(1, ref mi_x) &&
                    DA.GetData<Interval>(2, ref mi_y)
               )
            {
                Interval nx = new Interval();
                Interval ny = new Interval();
                double sf = 1.0;

                if(mi_x.Length >= mi_y.Length)
                {
                    nx = new Interval(0.0, 1.0);
                    ny = new Interval(0.0, mi_y.Length / mi_x.Length);
                    sf = mi_x.Length;
                }
                else 
                {
                    ny = new Interval(0.0, 1.0);
                    nx = new Interval(0.0, mi_x.Length / mi_y.Length);
                    sf = mi_y.Length;
                }

                List<Point3d> points = new List<Point3d>();
                InitSamplers();
                int pointCount = GeneratePts(samples);
                double m_x = nx.Length;
                double m_y = ny.Length;
                Point3d p = Point3d.Origin;
                for (int i = 0; i < pointCount - 1; i++)
                {
                    p = getPointAt(i);
                    if(nx.IncludesParameter(p.X) && ny.IncludesParameter(p.Y))
                    {
                        p *= sf;
                        p.X += mi_x.T0;
                        p.Y += mi_y.T0;

                        points.Add(p);
                    }  
                }

                DA.SetDataList(0, points);
            }
        }

        public override Guid ComponentGuid
        {
            get
            {
                return new Guid("{5d406e66-51a3-4b24-92ff-3ae1840609eb}");
            }
        }

        public override GH_Exposure Exposure
        {
            get
            {
                return GH_Exposure.secondary;
            }
        }

        protected override Bitmap Icon
        {
            get
            {
                return PointGenerator.Properties.Resources.Icon_BlueNoise_2D;
            }
        }
    }
}
