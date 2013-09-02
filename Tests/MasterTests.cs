using System;
using GitFlowVersion;
using NUnit.Framework;

[TestFixture]
public class MasterTests
{

    [Test]
    public void Should_throw_if_head_isnt_a_merge_commit()
    {
        Assert.Throws<Exception>(() => FinderWrapper.FindVersionForCommit("a682956dccae752aa24597a0f5cd939f93614509", "master"));
    }

    [Test]
    public void Commit_in_front_of_tag_should_return_tag_as_version()
    {
       //should throw
    }

    [Test]
    public void Hotfix_merge()
    {
        var version = FinderWrapper.FindVersionForCommit("290f97a0abd7000a22436b04d9535334f8e8f7ba", "master");
        Assert.AreEqual(0, version.Major);
        Assert.AreEqual(1, version.Minor);
        Assert.AreEqual(5, version.Patch,"Should set the patch version to the patch of the latest hotfix merge commit");
        Assert.AreEqual(Stage.Final, version.Stage);
        Assert.AreEqual(0, version.PreRelease);
    }

    [Test]
    public void Release_merge()
    {
        var version = FinderWrapper.FindVersionForCommit("716440a5409721b50c519cd73660a8a220c54d5f", "master");
        Assert.AreEqual(0, version.Major);
        Assert.AreEqual(2, version.Minor);
        Assert.AreEqual(0, version.Patch, "Should set the patch version to 0");
        Assert.AreEqual(Stage.Final, version.Stage);
        Assert.AreEqual(0, version.PreRelease);
    }

}