/* ***** BEGIN LICENSE BLOCK *****
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
 * The Original Code is Mozilla Universal charset detector code.
 *
 * The Initial Developer of the Original Code is
 * Netscape Communications Corporation.
 * Portions created by the Initial Developer are Copyright (C) 2001
 * the Initial Developer. All Rights Reserved.
 *
 * Contributor(s):
 *          Shy Shalom <shooshX@gmail.com>
 *          Rudi Pettazzi <rudi.pettazzi@gmail.com> (C# port)
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
* The implementation of this feature was originally done on https://gitlab.freedesktop.org/uchardet/uchardet/blob/master/src/LangModels/LangHungarianModel.cpp
* and adjusted to language specific support.
*/

namespace IX.Library.Globalization.CharsetDetection.Models.SingleByte.Hungarian;

internal class Iso_8859_2_HungarianModel : HungarianModel
{
    // Character Mapping Table:
    // ILL: illegal character.
    // CTR: control character specific to the charset.
    // RET: carriage/return.
    // SYM: symbol (punctuation) that does not belong to word.
    // NUM: 0 - 9.
    // 
    // Other characters are ordered by probabilities
    // (0 is the most common character in the language).
    // 
    // Orders are generic to a language. So the codepoint with order X in
    // CHARSET1 maps to the same character as the codepoint with the same
    // order X in CHARSET2 for the same language.
    // As such, it is possible to get missing order. For instance the
    // ligature of 'o' and 'e' exists in ISO-8859-15 but not in ISO-8859-1
    // even though they are both used for French. Same for the euro sign.

    private readonly static byte[] CHAR_TO_ORDER_MAP = {
        CTR,CTR,CTR,CTR,CTR,CTR,CTR,CTR,CTR,CTR,RET,CTR,CTR,RET,CTR,CTR, /* 0X */
        CTR,CTR,CTR,CTR,CTR,CTR,CTR,CTR,CTR,CTR,CTR,CTR,CTR,CTR,CTR,CTR, /* 1X */
        SYM,SYM,SYM,SYM,SYM,SYM,SYM,SYM,SYM,SYM,SYM,SYM,SYM,SYM,SYM,SYM, /* 2X */
        NUM,NUM,NUM,NUM,NUM,NUM,NUM,NUM,NUM,NUM,SYM,SYM,SYM,SYM,SYM,SYM, /* 3X */
        SYM,  1, 15, 23, 16,  0, 24, 13, 20,  7, 22,  9,  4, 12,  6,  8, /* 4X */
        21, 34,  5,  3,  2, 19, 17, 32, 33, 18, 10,SYM,SYM,SYM,SYM,SYM, /* 5X */
        SYM,  1, 15, 23, 16,  0, 24, 13, 20,  7, 22,  9,  4, 12,  6,  8, /* 6X */
        21, 34,  5,  3,  2, 19, 17, 32, 33, 18, 10,SYM,SYM,SYM,SYM,CTR, /* 7X */
        CTR,CTR,CTR,CTR,CTR,CTR,CTR,CTR,CTR,CTR,CTR,CTR,CTR,CTR,CTR,CTR, /* 8X */
        CTR,CTR,CTR,CTR,CTR,CTR,CTR,CTR,CTR,CTR,CTR,CTR,CTR,CTR,CTR,CTR, /* 9X */
        SYM, 55,SYM, 42,SYM, 56, 46,SYM,SYM, 37, 52, 57, 58,SYM, 48, 59, /* AX */
        SYM, 60,SYM, 42,SYM, 61, 46,SYM,SYM, 37, 52, 62, 63,SYM, 48, 64, /* BX */
        65, 11, 40, 36, 35, 66, 38, 39, 41, 14, 50, 67, 53, 28, 45, 68, /* CX */
        49, 43, 54, 26, 69, 27, 25,SYM, 44, 70, 30, 31, 29, 47, 51, 71, /* DX */
        72, 11, 40, 36, 35, 73, 38, 39, 41, 14, 50, 74, 53, 28, 45, 75, /* EX */
        49, 43, 54, 26, 76, 27, 25,SYM, 44, 77, 30, 31, 29, 47, 51,SYM, /* FX */
    };
    /*X0  X1  X2  X3  X4  X5  X6  X7  X8  X9  XA  XB  XC  XD  XE  XF */

    public Iso_8859_2_HungarianModel() : base(CHAR_TO_ORDER_MAP, CodepageName.ISO_8859_2)
    {
    }
}