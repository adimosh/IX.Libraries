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
* The implementation of this feature was originally done on https://gitlab.freedesktop.org/uchardet/uchardet/blob/master/src/LangModels/LangLatvianModel.cpp
* and adjusted to language specific support.
*/

namespace IX.Library.Globalization.CharsetDetection.Models.SingleByte.Latvian;

internal class Iso_8859_10_LatvianModel : LatvianModel
{
    // Generated by BuildLangModel.py
    // On: 2016-09-21 00:19:18.362275

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
        SYM,  0, 17, 22, 13,  3, 25, 19, 28,  1, 16, 11,  9, 12,  7, 10, /* 4X */
        15, 38,  4,  2,  5,  6, 14, 33, 35, 34, 20,SYM,SYM,SYM,SYM,SYM, /* 5X */
        SYM,  0, 17, 22, 13,  3, 25, 19, 28,  1, 16, 11,  9, 12,  7, 10, /* 6X */
        15, 38,  4,  2,  5,  6, 14, 33, 35, 34, 20,SYM,SYM,SYM,SYM,CTR, /* 7X */
        CTR,CTR,CTR,CTR,CTR,CTR,CTR,CTR,CTR,CTR,CTR,CTR,CTR,CTR,CTR,CTR, /* 8X */
        CTR,CTR,CTR,CTR,CTR,CTR,CTR,CTR,CTR,CTR,CTR,CTR,CTR,CTR,CTR,CTR, /* 9X */
        SYM, 88, 21, 31, 18, 89, 30,SYM, 26, 90, 23, 91, 29,SYM, 27, 48, /* AX */
        SYM, 92, 21, 31, 18, 93, 30,SYM, 26, 94, 23, 95, 29, 96, 27, 48, /* BX */
        8, 42, 97, 98, 40, 52, 53, 99, 32, 37,100, 43, 46, 45, 49,101, /* CX */
        50, 24, 51, 47,102,103, 36,104,105,106,107,108, 39,109, 54, 44, /* DX */
        8, 42,110,111, 40, 52, 53,112, 32, 37,113, 43, 46, 45, 49,114, /* EX */
        50, 24, 51, 47,115,116, 36,117,118,119,120,121, 39,122, 54,123, /* FX */
    };
    /*X0  X1  X2  X3  X4  X5  X6  X7  X8  X9  XA  XB  XC  XD  XE  XF */

    public Iso_8859_10_LatvianModel() : base(CHAR_TO_ORDER_MAP, CodepageName.ISO_8859_10)
    {
    }
}