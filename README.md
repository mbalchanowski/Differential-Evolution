# Differential-Evolution
Simple console implementation of the Differential Evolution (DE) algorithm as described in: *Storn, R.,  Price, K.: "Differential Evolution – A Simple and Efficient Heuristic for global Optimization over Continuous Spaces", Journal of Global Optimization (1997)*

More info: https://en.wikipedia.org/wiki/Differential_evolution

It is written in **C# (build with .NET Core 2.0)**

# Running

By default it tries to solve `RASTRIGIN FUNCTION` for only 2 dimensions but of course you can increase dimensions or add more functions in `TestFunction.cs`

# Parameters
Default parameters (file `Parameters.cs`):
* Amplification Factor (F) - 0.5
* Crossover Probability (CR) - 0.9
* Agents Count - 20
* Iterations - 100 (highly depends on problem and number of dimensions)

# License

MIT License

Copyright (c) 2018 mbalchanowski

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.