# -*- coding: utf-8 -*-

import os
import re
import sys
import subprocess
import shutil


NUGET = '../src/.nuget/nuget'
NUNIT = 'nunit-console'
MSBUILD = 'msbuild'
SIGNKEY = 'candy.snk'


class Target(object):
    def __init__(self, solution, framework):
        self.solution = solution
        self.framework = framework


targets = [
    Target('../src/Candy.netfx35.sln', 'net35'),
    Target('../src/Candy.netfx40.sln', 'net40'),
    Target('../src/Candy.netfx45.sln', 'net45'),
]


def pack():
    for target in targets:
        # build & sign
        signfile = os.path.join(os.getcwd(), SIGNKEY)
        buildargs = [MSBUILD, target.solution, '/p:Configuration=Release', '/p:Platform=Any CPU']
        if os.path.exists(signfile):
            buildargs.append('/p:AssemblyOriginatorKeyFile='+signfile)
            buildargs.append('/p:SignAssembly=true')
        retcode = subprocess.call(buildargs)
        if retcode:
            print('[!] Cannot build %s' % target.solution)
            exit(1)
        # test
        retcode = subprocess.call([NUNIT, '../src/Candy.Tests/bin/Release/Candy.Tests.dll', '/nologo', '/noresult'])
        if retcode:
            print('[!] Cannot run tests for %s' % target.solution)
            exit(1)
        # copy
        path = os.path.join('lib', target.framework)
        if not os.path.exists(path):
            os.makedirs(path)
        shutil.copy('../src/Candy/bin/Release/Candy.dll', path)
        shutil.copy('../src/Candy/bin/Release/Candy.xml', path)
    # get version from AssemblyInfo.cs
    f = open('../src/Candy/Properties/AssemblyInfo.cs', 'r')
    version = re.findall(r'AssemblyVersion\(\"(\d+.\d+.\d+).\d+\"\)', f.read())[0]
    f.close()
    # pack
    retcode = subprocess.call([NUGET, 'pack', 'Candy.nuspec', '-Version', version])
    if retcode:
        print('[!] Cannot make package')
        exit(1)


if __name__ == '__main__':
    arg = sys.argv[1] if len(sys.argv) > 1 else None
    if not arg:
        print('Available commands: pack')
        exit(0)

    globals()[arg]()