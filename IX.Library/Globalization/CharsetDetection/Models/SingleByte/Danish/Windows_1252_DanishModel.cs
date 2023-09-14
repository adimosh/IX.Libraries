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
* The implementation of this feature was originally done on https://gitlab.freedesktop.org/uchardet/uchardet/blob/master/src/LangModels/LangDanishModel.cpp
* and adjusted to language specific support.
*/

namespace IX.Library.Globalization.CharsetDetection.Models.SingleByte.Danish;

internal class Windows_1252_DanishModel : DanishModel
{
    // Generated by BuildLangModel.py
    // On: 2016-02-19 17:56:42.163975

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
        SYM,  4, 15, 24,  7,  0, 13, 10, 18,  5, 23, 11,  8, 12,  2,  9, /* 4X */
        17, 29,  1,  6,  3, 16, 14, 25, 27, 20, 26,SYM,SYM,SYM,SYM,SYM, /* 5X */
        SYM,  4, 15, 24,  7,  0, 13, 10, 18,  5, 23, 11,  8, 12,  2,  9, /* 6X */
        17, 29,  1,  6,  3, 16, 14, 25, 27, 20, 26,SYM,SYM,SYM,SYM,CTR, /* 7X */
        SYM,ILL,SYM, 84,SYM,SYM,SYM,SYM,SYM,SYM, 39,SYM, 85,ILL, 86,ILL, /* 8X */
        ILL,SYM,SYM,SYM,SYM,SYM,SYM,SYM,SYM,SYM, 39,SYM, 87,ILL, 88, 89, /* 9X */
        SYM,SYM,SYM,SYM,SYM,SYM,SYM,SYM,SYM,SYM,SYM,SYM,SYM,SYM,SYM,SYM, /* AX */
        SYM,SYM,SYM,SYM,SYM, 42,SYM,SYM,SYM,SYM,SYM,SYM,SYM,SYM,SYM,SYM, /* BX */
        90, 33, 40, 35, 32, 21, 22, 38, 41, 28, 49, 45, 91, 34, 92, 50, /* CX */
        43, 47, 51, 36, 52, 93, 30,SYM, 19, 94, 37, 44, 31, 46, 95, 48, /* DX */
        96, 33, 40, 35, 32, 21, 22, 38, 41, 28, 49, 45, 97, 34, 98, 50, /* EX */
        43, 47, 51, 36, 52, 99, 30,SYM, 19,100, 37, 44, 31, 46,101,102, /* FX */
    };
    /*X0  X1  X2  X3  X4  X5  X6  X7  X8  X9  XA  XB  XC  XD  XE  XF */

    public Windows_1252_DanishModel() : base(CHAR_TO_ORDER_MAP, CodepageName.WINDOWS_1252)
    {
    }
}