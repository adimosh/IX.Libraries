﻿/* ***** BEGIN LICENSE BLOCK *****
 * Version: MPL 1.1/GPL 2.0/LGPL 2.1
 *
 * The contents of this file are subject to the Mozilla Public License Version
 * 1.1 (the "License"); you may not use this file except in compliance with
 * the License. You may obtain a copy of the License at
 * http://www.mozilla.org/MPL/
 *
 * Software distributed under the License is distributed on an "AS IS" basis,
 * WITHOUT WARRANTY OF ANY KIND, either express or implied. See the License
 * for the specific language governing rights and limitations under the
 * License.
 *
 * The Original Code is Mozilla Communicator client code.
 *
 * The Initial Developer of the Original Code is
 * Netscape Communications Corporation.
 * Portions created by the Initial Developer are Copyright (C) 1998
 * the Initial Developer. All Rights Reserved.
 *
 * Contributor(s):
 *
 * Alternatively, the contents of this file may be used under the terms of
 * either the GNU General Public License Version 2 or later (the "GPL"), or
 * the GNU Lesser General Public License Version 2.1 or later (the "LGPL"),
 * in which case the provisions of the GPL or the LGPL are applicable instead
 * of those above. If you wish to allow use of your version of this file only
 * under the terms of either the GPL or the LGPL, and not to allow others to
 * use your version of this file under the terms of the MPL, indicate your
 * decision by deleting the provisions above and replace them with the notice
 * and other provisions required by the GPL or the LGPL. If you do not delete
 * the provisions above, a recipient may use your version of this file under
 * the terms of any one of the MPL, the GPL or the LGPL.
 *
 * ***** END LICENSE BLOCK ***** */

/*
* The following part was imported from https://gitlab.freedesktop.org/uchardet/uchardet
* The implementation of this feature was originally done on https://gitlab.freedesktop.org/uchardet/uchardet/blob/master/src/LangModels/LangRomanianModel.cpp
* and adjusted to language specific support.
*/

namespace IX.Library.Globalization.CharsetDetection.Models.SingleByte.Romanian;

internal class Windows_1250_RomanianModel : RomanianModel
{
    // Generated by BuildLangModel.py
    // On: 2016-09-28 18:58:13.757152

    // Character Mapping Table:
    // ILL: illegal character.
    // CTR: control character specific to the charset.
    // RET: carriage/return.
    // SYM: symbol (punctuation) that does not belong to word.
    // NUM: 0 - 9.

    // Other characters are ordered by probabilities
    // (0 is the most common character in the language).

    // Orders are generic to a language. So the codepoint with order X in
    // CHARSET1 maps to the same character as the codepoint with the same
    // order X in CHARSET2 for the same language.
    // As such, it is possible to get missing order. For instance the
    // ligature of 'o' and 'e' exists in ISO-8859-15 but not in ISO-8859-1
    // even though they are both used for French. Same for the euro sign.

    private static byte[] CHAR_TO_ORDER_MAP = {
        CTR,CTR,CTR,CTR,CTR,CTR,CTR,CTR,CTR,CTR,RET,CTR,CTR,RET,CTR,CTR, /* 0X */
        CTR,CTR,CTR,CTR,CTR,CTR,CTR,CTR,CTR,CTR,CTR,CTR,CTR,CTR,CTR,CTR, /* 1X */
        SYM,SYM,SYM,SYM,SYM,SYM,SYM,SYM,SYM,SYM,SYM,SYM,SYM,SYM,SYM,SYM, /* 2X */
        NUM,NUM,NUM,NUM,NUM,NUM,NUM,NUM,NUM,NUM,SYM,SYM,SYM,SYM,SYM,SYM, /* 3X */
        SYM,  2, 17,  9, 11,  0, 16, 15, 23,  1, 26, 27,  6, 12,  4,  8, /* 4X */
        13, 32,  3, 10,  5,  7, 21, 29, 25, 28, 22,SYM,SYM,SYM,SYM,SYM, /* 5X */
        SYM,  2, 17,  9, 11,  0, 16, 15, 23,  1, 26, 27,  6, 12,  4,  8, /* 6X */
        13, 32,  3, 10,  5,  7, 21, 29, 25, 28, 22,SYM,SYM,SYM,SYM,CTR, /* 7X */
        SYM,ILL,SYM,ILL,SYM,SYM,SYM,SYM,ILL,SYM, 38,SYM, 56,110, 40,111, /* 8X */
        ILL,SYM,SYM,SYM,SYM,SYM,SYM,SYM,ILL,SYM, 38,SYM, 56,112, 40,113, /* 9X */
        SYM,SYM,SYM, 46,SYM,114,SYM,SYM,SYM,SYM,115,SYM,SYM,SYM,SYM,116, /* AX */
        SYM,SYM,SYM, 46,SYM,SYM,SYM,SYM,SYM,117,118,SYM,119,SYM,120,121, /* BX */
        122, 30, 24, 14, 33,123, 35, 42, 41, 31,124, 49, 51, 37, 20,125, /* CX */
        43, 52,126, 34,127, 44, 36,SYM, 55,128, 47, 50, 39, 54,129, 57, /* DX */
        130, 30, 24, 14, 33,131, 35, 42, 41, 31,132, 49, 51, 37, 20,133, /* EX */
        43, 52,134, 34,135, 44, 36,SYM, 55,136, 47, 50, 39, 54,137,SYM, /* FX */
    };
    /*X0  X1  X2  X3  X4  X5  X6  X7  X8  X9  XA  XB  XC  XD  XE  XF */

    public Windows_1250_RomanianModel() : base(CHAR_TO_ORDER_MAP, CodepageName.WINDOWS_1250)
    {
    }
}