# LowDisc-BlueNoise-PointGenerator

## 2D Point Generator using Low Disc Blue Noise Sampling
This is a C# project which will generate a bounded two-dimensional point set for [Grasshopper](https://discourse.mcneel.com/c/grasshopper)/[Rhino](https://www.rhino3d.com/) by wrapping the [Low Disc Blue Noise Point Sampling C++ library](https://github.com/dcoeurjo/LowDiscBlueNoise) written by David Coeurjolly.

## License

```
/*
 * Reference-matching code for LDBN in the paper:
 *      Ahmed, Perrier, Coeurjolly, Ostromoukhov, Guo, Yan, Huang, and Deussen
 *      Low-Discrepancy Blue Noise Sampling
 *      SIGGRAPH Asia 2016
 *
 * Coded by Abdalla G. M. Ahmed, 2016-09-19.
 * Copyright (c) 2016, Abdalla G. M. Ahmed
 * All rights reserved.
 *
 * Refactoring by David Coeurjolly 2018-11-22
 *
 * Refactoring for Grasshopper by Andrew O. Payne 2020-04-24
 *
 * Redistribution and use in source and binary forms, with or without
 * modification, are permitted provided that the following conditions are met:
 *
 * 1. Redistributions of source code must retain the above copyright notice, this
 *    list of conditions and the following disclaimer.
 * 2. Redistributions in binary form must reproduce the above copyright notice,
 *    this list of conditions and the following disclaimer in the documentation
 *    and/or other materials provided with the distribution.
 *
 * THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND
 * ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED
 * WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
 * DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE LIABLE FOR
 * ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES
 * (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES;
 * LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND
 * ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT
 * (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS
 * SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
 *
 * The views and conclusions contained in the software and documentation are those
 * of the authors and should not be interpreted as representing official policies,
 * either expressed or implied, of the LDBN project.
 */
 ```