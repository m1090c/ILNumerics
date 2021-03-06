﻿#region ORIGINS, COPYRIGHTS, AND LICENSE
/*

This C# version of LAPACK is derivied from http://www.netlib.org/clapack/,
and the original copyright and license is as follows:

Copyright (c) 1992-2008 The University of Tennessee.  All rights reserved.
$COPYRIGHT$ Additional copyrights may follow $HEADER$

Redistribution and use in source and binary forms, with or without
modification, are permitted provided that the following conditions are
met:

- Redistributions of source code must retain the above copyright
  notice, this list of conditions and the following disclaimer. 
  
- Redistributions in binary form must reproduce the above copyright
  notice, this list of conditions and the following disclaimer listed
  in this license in the documentation and/or other materials
  provided with the distribution.
  
- Neither the name of the copyright holders nor the names of its
  contributors may be used to endorse or promote products derived from
  this software without specific prior written permission.
  
THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS
"AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT  
LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR
A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT 
OWNER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL,
SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT
LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE,
DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY
THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT  
(INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE
OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
 */
#endregion

public partial class ManagedLapack
{
    public static unsafe int dlatrz(int m, int n, int l, double* a, int lda, double* tau, double* work)
    {
        /* System generated locals */
        int a_dim1, a_offset, i__1, i__2;

        /* Local variables */
        int i__;

        /* Parameter adjustments */
        a_dim1 = lda;
        a_offset = 1 + a_dim1;
        a -= a_offset;
        --tau;
        --work;

        /* Function Body */
        if (m == 0) {
	    return 0;
        } else if (m == n) {
	    i__1 = n;
	    for (i__ = 1; i__ <= i__1; ++i__) {
	        tau[i__] = 0.0;
    /* L10: */
	    }
	    return 0;
        }

        for (i__ = m; i__ >= 1; --i__) {

    /*        Generate elementary reflector H(i) to annihilate */
    /*        [ A(i,i) A(i,n-l+1:n) ] */

	    i__1 = l + 1;
	    dlarfg(i__1, ref a[i__ + i__ * a_dim1], &a[i__ + (n - l + 1) * 
		    a_dim1], lda, ref tau[i__]);

    /*        Apply H(i) to A(1:i-1,i:n) from the right */

	    i__1 = i__ - 1;
	    i__2 = n - i__ + 1;
	    dlarz('R', i__1, i__2, l, &a[i__ + (n - l + 1) * a_dim1], 
		    lda, tau[i__], &a[i__ * a_dim1 + 1], lda, &work[1]);

    /* L20: */
        }

        return 0;
    } 
}

