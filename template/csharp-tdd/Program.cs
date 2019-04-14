// Copyright (c) Alex Ellis 2017. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Text;
using Function;
using OpenFaaS.Dotnet;

namespace root
{
    class Program
    {
        static void Main(string[] args)
        {
            string buffer = Console.In.ReadToEnd();
            var context = new DefaultFunctionContext();

            FunctionHandler f = new FunctionHandler(context);
            string responseValue = f.Handle(buffer);

            if(responseValue != null) {
                Console.Write(responseValue);
            }
        }
    }
}
