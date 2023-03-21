namespace Geometry_Test;

using Geometry;

[TestClass]
public class CylinderTest
{
    [TestMethod]
    public void VolumeParameter_h2r3_True()
    {
        var tmp = new Cylinder(1, 1, 2, 3);
        var vol = tmp.Volume;
        Assert.IsTrue(Equals(vol, Math.PI * 9 * 2), "Calculated volumes should be equal");
    }

    [TestMethod]
    public void VolumeStaticMethod_h2r3_True(){
        var vol = Cylinder.CalcVolume(2, 3);
        Assert.IsTrue(Equals(vol, Math.PI * 9 * 2), "Calculated volumes should be equal");
    }

    [TestMethod]
    public void CylinderCtor_r0_True(){
        var tmp = new Cylinder(1, 1, 1, 0);
        Assert.IsTrue(Equals(tmp.r, 1.0), "If value of r is less or equals to 0 it \nshould be set to default which is 1");
    }

    [TestMethod]
    public void CylinderCtor_h0_True(){
        var tmp = new Cylinder(1, 1, 0, 1);
        Assert.IsTrue(Equals(tmp.h, 1.0), "If value of h is less or equals to 0 it \nshould be set to default which is 1");
    }

    [TestMethod]
    public void VolumeStaticMethod_hLessThen0_True(){
        var vol = Cylinder.CalcVolume(-2, 3);
        Assert.IsTrue(Equals(vol, 0.0), "If value of h is less or equals to 0 then volume will be 0");
    }

    [TestMethod]
    public void VolumeStaticMethod_rLessThen0_True(){
        var vol = Cylinder.CalcVolume(3, -3);
        Assert.IsTrue(Equals(vol, 0.0), "If value of r is less or equals to 0 then volume will be 0");
    }
}