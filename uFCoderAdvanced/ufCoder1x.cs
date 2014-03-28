using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.IO;
namespace  Mifare
{
    using DL_STATUS = System.UInt32;
    unsafe class  ufCoder1x
    {
       
        [DllImport("uFCoder1x.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto,EntryPoint="ReaderOpen" )]
        public static extern DL_STATUS ReaderOpen() ;

        [DllImport( "uFCoder1x.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto,EntryPoint="ReaderClose")]
        public static extern DL_STATUS ReaderClose ();

        [DllImport("uFCoder1x.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto, EntryPoint = "ReaderReset")]
        public static extern DL_STATUS ReaderReset();

        [DllImport("uFCoder1x.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto, EntryPoint = "ReaderSoftRestart")]
        public static extern DL_STATUS ReaderSoftRestart();

        [DllImport( "uFCoder1x.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto,EntryPoint="GetReaderType" )]
        public static  extern DL_STATUS GetReaderType (ulong* get_reader_type);

         [DllImport( "uFCoder1x.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto,EntryPoint="ReaderKeyWrite" )]
       public static extern DL_STATUS ReaderKeyWrite(byte* aucKey, byte ucKeyIndex);

        [DllImport("uFCoder1x.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto, EntryPoint = "GetReaderSerialNumber")]
        public  static extern DL_STATUS GetReaderSerialNumber (ulong* serial_number);

        [DllImport("uFCoder1x.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto, EntryPoint = "GetCardId")]
        public static extern DL_STATUS GetCardId(byte* card_type, ulong* card_serial);

        [DllImport("uFCoder1x.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto, EntryPoint = "ReaderUISignal")]
        public static extern DL_STATUS ReaderUISignal(int light_mode, int sound_mode);

        [DllImport("uFCoder1x.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto, EntryPoint = "ReadUserData")]
        public static extern DL_STATUS ReadUserData(byte* aucData);

        [DllImport("uFCoder1x.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto, EntryPoint = "WriteUserData")]
        public static extern DL_STATUS  WriteUserData(byte* aucData);

        [DllImport("uFCoder1x.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto, EntryPoint = "LinearRead")]
        public static extern DL_STATUS LinearRead(byte* aucData,
                                                   ushort linear_address,
                                                   ushort data_len,
                                                   ushort* bytes_written,
                                                   byte key_mode,
                                                   byte key_index);

        [DllImport("uFCoder1x.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto, EntryPoint = "LinearRead_AKM1")]
        public static extern DL_STATUS LinearRead_AKM1(byte* aucData,
                                                   ushort linear_address,
                                                   ushort data_len,
                                                   ushort* bytes_written,
                                                   byte key_mode);

        [DllImport("uFCoder1x.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto, EntryPoint = "LinearRead_AKM2")]
        public static extern DL_STATUS LinearRead_AKM2(byte* aucData,
                                                   ushort linear_address,
                                                   ushort data_len,
                                                   ushort* bytes_written,
                                                   byte key_mode);

        [DllImport("uFCoder1x.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto, EntryPoint = "LinearRead_PK")]
        public static extern DL_STATUS LinearRead_PK(byte* aucData,
                                                   ushort linear_address,
                                                   ushort data_len,
                                                   ushort* bytes_written,
                                                   byte key_mode,
                                                   byte* pk_key);

        [DllImport("uFCoder1x.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto, EntryPoint = "LinearWrite")]
        public static extern DL_STATUS LinearWrite (byte* aucData,
                                                    ushort linear_address,
                                                    ushort data_len,
                                                    ushort* bytes_written,
                                                    byte auth_mode, 
                                                    byte key_index);

        [DllImport("uFCoder1x.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto, EntryPoint = "LinearWrite_AKM1")]
        public static extern DL_STATUS LinearWrite_AKM1(byte* aucData,
                                                    ushort linear_address,
                                                    ushort data_len,
                                                    ushort* bytes_written,
                                                    byte auth_mode);

        [DllImport("uFCoder1x.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto, EntryPoint = "LinearWrite_AKM2")]
        public static extern DL_STATUS LinearWrite_AKM2(byte* aucData,
                                                    ushort linear_address,
                                                    ushort data_len,
                                                    ushort* bytes_written,
                                                    byte auth_mode);

        [DllImport("uFCoder1x.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto, EntryPoint = "LinearWrite_PK")]
        public static extern DL_STATUS LinearWrite_PK(byte* aucData,
                                                   ushort linear_address,
                                                   ushort data_len,
                                                   ushort* bytes_written,
                                                   byte key_mode,
                                                   byte* pk_key);

        [DllImport("uFCoder1x.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto, EntryPoint = "BlockRead")]
        public static extern DL_STATUS  BlockRead(byte* data,
                                                  byte block_address,
                                                  byte auth_mode,
                                                  byte key_index);

        [DllImport("uFCoder1x.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto, EntryPoint = "BlockRead_AKM1")]
        public static extern DL_STATUS BlockRead_AKM1(byte* data,
                                                  byte block_address,
                                                  byte auth_mode);

        [DllImport("uFCoder1x.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto, EntryPoint = "BlockRead_AKM2")]
        public static extern DL_STATUS BlockRead_AKM2(byte* data,
                                                  byte block_address,
                                                  byte auth_mode);

        [DllImport("uFCoder1x.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto, EntryPoint = "BlockRead_PK")]
        public static extern DL_STATUS BlockRead_PK(byte* data,
                                                  byte block_address,
                                                  byte auth_mode,
                                                  byte* pk_key);

        [DllImport("uFCoder1x.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto, EntryPoint = "BlockWrite")]
        public static extern DL_STATUS BlockWrite(byte* data,
                                                  byte block_address,
                                                  byte auth_mode,
                                                  byte key_index);

        [DllImport("uFCoder1x.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto, EntryPoint = "BlockWrite_AKM1")]
        public static extern DL_STATUS BlockWrite_AKM1(byte* data,
                                                       byte block_address,
                                                       byte auth_mode);


        [DllImport("uFCoder1x.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto, EntryPoint = "BlockWrite_AKM2")]
        public static extern DL_STATUS BlockWrite_AKM2(byte* data,
                                                       byte block_address,
                                                       byte auth_mode);

        [DllImport("uFCoder1x.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto, EntryPoint = "BlockWrite_PK")]
        public static extern DL_STATUS BlockWrite_PK(byte* data,
                                                       byte block_address,
                                                       byte auth_mode,
                                                       byte* pk_key);

         [DllImport("uFCoder1x.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto, EntryPoint = "BlockInSectorRead")]
          public static extern DL_STATUS BlockInSectorRead(byte* data,
                                                           byte sector_address,
                                                           byte block_in_sector_address,
                                                           byte auth_mode,byte key_index);


         [DllImport("uFCoder1x.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto, EntryPoint = "BlockInSectorRead_AKM1")]
         public static extern DL_STATUS BlockInSectorRead_AKM1(byte* data,
                                                               byte sector_address,
                                                               byte block_in_sector_address,
                                                               byte auth_mode);


         [DllImport("uFCoder1x.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto, EntryPoint = "BlockInSectorRead_AKM2")]
         public static extern DL_STATUS BlockInSectorRead_AKM2(byte* data,
                                                               byte sector_address,
                                                               byte block_in_sector_address,
                                                               byte auth_mode);

         [DllImport("uFCoder1x.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto, EntryPoint = "BlockInSectorRead_PK")]
         public static extern DL_STATUS BlockInSectorRead_PK(byte* data,
                                                             byte sector_address,
                                                             byte block_in_sector_address,
                                                             byte auth_mode,
                                                             byte* pk_key);

        [DllImport("uFCoder1x.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto, EntryPoint = "BlockInSectorWrite")]
        public static extern DL_STATUS BlockInSectorWrite(byte* data,
                                                            byte sector_address,
                                                            byte block_in_sector_address,
                                                            byte auth_mode,
                                                            byte key_index);

        [DllImport("uFCoder1x.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto, EntryPoint = "BlockInSectorWrite_AKM1")]
        public static extern DL_STATUS BlockInSectorWrite_AKM1(byte* data,
                                                               byte sector_address,
                                                               byte block_in_sector_address,
                                                               byte auth_mode);


        [DllImport("uFCoder1x.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto, EntryPoint = "BlockInSectorWrite_AKM2")]
        public static extern DL_STATUS BlockInSectorWrite_AKM2(byte* data,
                                                               byte sector_address,
                                                               byte block_in_sector_address,
                                                               byte auth_mode);

        [DllImport("uFCoder1x.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto, EntryPoint = "BlockInSectorWrite_PK")]
        public static extern DL_STATUS BlockInSectorWrite_PK(byte* data,
                                                             byte sector_address,
                                                             byte block_in_sector_address,
                                                             byte auth_mode,
                                                             byte* pk_key);

        [DllImport("uFCoder1x.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto, EntryPoint = "ValueBlockRead")]
        public static extern DL_STATUS   ValueBlockRead(int* value,
                                                        byte* value_addr,
                                                        byte block_address,
                                                        byte auth_mode,
                                                        byte key_index);

        [DllImport("uFCoder1x.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto, EntryPoint = "ValueBlockRead_AKM1")]
        public static extern DL_STATUS ValueBlockRead_AKM1(int* value,
                                                        byte* value_addr,
                                                        byte block_address,
                                                        byte auth_mode);

        [DllImport("uFCoder1x.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto, EntryPoint = "ValueBlockRead_AKM2")]
        public static extern DL_STATUS ValueBlockRead_AKM2(int* value,
                                                        byte* value_addr,
                                                        byte block_address,
                                                        byte auth_mode);

        [DllImport("uFCoder1x.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto, EntryPoint = "ValueBlockRead_PK")]
        public static extern DL_STATUS ValueBlockRead_PK(int* value,
                                                        byte* value_addr,
                                                        byte block_address,
                                                        byte auth_mode,
                                                        byte* pk_key);

        [DllImport("uFCoder1x.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto, EntryPoint = "ValueBlockWrite")]
        public static extern DL_STATUS ValueBlockWrite( int value,
                                                        byte value_addr,
                                                        byte block_address,
                                                        byte auth_mode,
                                                        byte key_index);

        [DllImport("uFCoder1x.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto, EntryPoint = "ValueBlockWrite_AKM1")]
        public static extern DL_STATUS ValueBlockWrite_AKM1(int value,
                                                        byte value_addr,
                                                        byte block_address,
                                                        byte auth_mode);

        [DllImport("uFCoder1x.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto, EntryPoint = "ValueBlockWrite_AKM2")]
        public static extern DL_STATUS ValueBlockWrite_AKM2(int value,
                                                        byte value_addr,
                                                        byte block_address,
                                                        byte auth_mode);

        [DllImport("uFCoder1x.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto, EntryPoint = "ValueBlockWrite_PK")]
        public static extern DL_STATUS ValueBlockWrite_PK(int value,
                                                        byte value_addr,
                                                        byte block_address,
                                                        byte auth_mode,
                                                        byte* pk_key);

        [DllImport("uFCoder1x.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto, EntryPoint = "ValueBlockIncrement")]
        public static extern DL_STATUS  ValueBlockIncrement(int increment_value,
                                                             byte block_address,
                                                             byte auth_mode,
                                                             byte key_index);

        [DllImport("uFCoder1x.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto, EntryPoint = "ValueBlockIncrement_AKM1")]
        public static extern DL_STATUS ValueBlockIncrement_AKM1(int increment_value,
                                                                byte block_address,
                                                                byte auth_mode);

        [DllImport("uFCoder1x.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto, EntryPoint = "ValueBlockIncrement_AKM2")]
        public static extern DL_STATUS ValueBlockIncrement_AKM2(int increment_value,
                                                                byte block_address,
                                                                byte auth_mode);

        [DllImport("uFCoder1x.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto, EntryPoint = "ValueBlockIncrement_PK")]
        public static extern DL_STATUS ValueBlockIncrement_PK(int increment_value,
                                                                byte block_address,
                                                                byte auth_mode,
                                                                byte* pk_key);

        [DllImport("uFCoder1x.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto, EntryPoint = "ValueBlockDecrement")]
        public static extern DL_STATUS ValueBlockDecrement(int increment_value,
                                                             byte block_address,
                                                             byte auth_mode,
                                                             byte key_index);

        [DllImport("uFCoder1x.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto, EntryPoint = "ValueBlockDecrement_AKM1")]
        public static extern DL_STATUS ValueBlockDecrement_AKM1(int increment_value,
                                                                byte block_address,
                                                                byte auth_mode);

        [DllImport("uFCoder1x.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto, EntryPoint = "ValueBlockDecrement_AKM2")]
        public static extern DL_STATUS ValueBlockDecrement_AKM2(int increment_value,
                                                                byte block_address,
                                                                byte auth_mode);

        [DllImport("uFCoder1x.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto, EntryPoint = "ValueBlockDecrement_PK")]
        public static extern DL_STATUS ValueBlockDecrement_PK(int increment_value,
                                                                byte block_address,
                                                                byte auth_mode,
                                                                byte* pk_key);
        
         [DllImport("uFCoder1x.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto, EntryPoint = "ValueBlockInSectorRead")]
         public static extern   DL_STATUS  ValueBlockInSectorRead(Int32 *value,
                                                                  byte* value_addr,
                                                                  byte sector_address,
                                                                  byte block_in_sector_address,
                                                                  byte auth_mode,
                                                                  byte key_index);

         [DllImport("uFCoder1x.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto, EntryPoint = "ValueBlockInSectorRead_AKM1")]
         public static extern DL_STATUS ValueBlockInSectorRead_AKM1(Int32* value,
                                                                  byte* value_addr,
                                                                  byte sector_address,
                                                                  byte block_in_sector_address,
                                                                  byte auth_mode);


         [DllImport("uFCoder1x.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto, EntryPoint = "ValueBlockInSectorRead_AKM2")]
         public static extern DL_STATUS ValueBlockInSectorRead_AKM2(Int32* value,
                                                                  byte* value_addr,
                                                                  byte sector_address,
                                                                  byte block_in_sector_address,
                                                                  byte auth_mode);

         [DllImport("uFCoder1x.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto, EntryPoint = "ValueBlockInSectorRead_PK")]
         public static extern DL_STATUS ValueBlockInSectorRead_PK(Int32* value,
                                                                  byte* value_addr,
                                                                  byte sector_address,
                                                                  byte block_in_sector_address,
                                                                  byte auth_mode,
                                                                  byte* pk_key);

         [DllImport("uFCoder1x.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto, EntryPoint = "ValueBlockInSectorWrite")]
         public static extern DL_STATUS ValueBlockInSectorWrite(Int32 value,
                                                                byte value_addr,            
                                                                byte sector_address,
                                                                byte block_in_sector_address,
                                                                byte auth_mode,byte key_index);

         [DllImport("uFCoder1x.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto, EntryPoint = "ValueBlockInSectorWrite_AKM1")]
         public static extern DL_STATUS ValueBlockInSectorWrite_AKM1(Int32 value,
                                                                byte value_addr,
                                                                byte sector_address,
                                                                byte block_in_sector_address,
                                                                byte auth_mode);

         [DllImport("uFCoder1x.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto, EntryPoint = "ValueBlockInSectorWrite_AKM2")]
         public static extern DL_STATUS ValueBlockInSectorWrite_AKM2(Int32 value,
                                                                byte value_addr,
                                                                byte sector_address,
                                                                byte block_in_sector_address,
                                                                byte auth_mode);

         [DllImport("uFCoder1x.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto, EntryPoint = "ValueBlockInSectorWrite_PK")]
         public static extern DL_STATUS ValueBlockInSectorWrite_PK(Int32 value,
                                                                byte value_addr,
                                                                byte sector_address,
                                                                byte block_in_sector_address,
                                                                byte auth_mode,
                                                                byte* pk_key); 

          [DllImport("uFCoder1x.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto, EntryPoint = "ValueBlockInSectorIncrement")]
          public static extern DL_STATUS  ValueBlockInSectorIncrement(Int32 increment_value,
                                                                      byte sector_address,          
                                                                      byte block_in_sector_address,           
                                                                      byte auth_mode,
                                                                      byte key_index);

          [DllImport("uFCoder1x.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto, EntryPoint = "ValueBlockInSectorIncrement_AKM1")]
          public static extern DL_STATUS ValueBlockInSectorIncrement_AKM1(Int32 increment_value,
                                                                      byte sector_address,
                                                                      byte block_in_sector_address,
                                                                      byte auth_mode);

          [DllImport("uFCoder1x.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto, EntryPoint = "ValueBlockInSectorIncrement_AKM2")]
          public static extern DL_STATUS ValueBlockInSectorIncrement_AKM2(Int32 increment_value,
                                                                      byte sector_address,
                                                                      byte block_in_sector_address,
                                                                      byte auth_mode);


          [DllImport("uFCoder1x.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto, EntryPoint = "ValueBlockInSectorIncrement_PK")]
          public static extern DL_STATUS ValueBlockInSectorIncrement_PK(Int32 increment_value,
                                                                      byte sector_address,
                                                                      byte block_in_sector_address,
                                                                      byte auth_mode,
                                                                      byte* pk_key);

         [DllImport("uFCoder1x.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto, EntryPoint = "ValueBlockInSectorDecrement")]
          public static extern DL_STATUS  ValueBlockInSectorDecrement(Int32 decrement_value,
                                                                      byte sector_address,
                                                                      byte block_in_sector_address,
                                                                      byte auth_mode,
                                                                      byte key_index);

         [DllImport("uFCoder1x.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto, EntryPoint = "ValueBlockInSectorDecrement_AKM1")]
         public static extern DL_STATUS ValueBlockInSectorDecrement_AKM1(Int32 decrement_value,
                                                                     byte sector_address,
                                                                     byte block_in_sector_address,
                                                                     byte auth_mode);


         [DllImport("uFCoder1x.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto, EntryPoint = "ValueBlockInSectorDecrement_AKM2")]
         public static extern DL_STATUS ValueBlockInSectorDecrement_AKM2(Int32 decrement_value,
                                                                     byte sector_address,
                                                                     byte block_in_sector_address,
                                                                     byte auth_mode);


         [DllImport("uFCoder1x.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto, EntryPoint = "ValueBlockInSectorDecrement_PK")]
         public static extern DL_STATUS ValueBlockInSectorDecrement_PK(Int32 decrement_value,
                                                                     byte sector_address,
                                                                     byte block_in_sector_address,
                                                                     byte auth_mode,
                                                                     byte* pk_key);

         [DllImport("uFCoder1x.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto, EntryPoint = "SectorTrailerWrite")]
         public static extern DL_STATUS SectorTrailerWrite(byte addressing_mode,
                                         byte address,
                                         byte* new_key_A,
                                         byte block0_access_bits,
                                         byte block1_access_bits,
                                         byte block2_access_bits,
                                         byte sector_trailer_access_bits,
                                         byte sector_trailer_byte9,
                                         byte* new_key_B,
                                         byte auth_mode,
                                         byte key_index);

         [DllImport("uFCoder1x.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto, EntryPoint = "SectorTrailerWrite_AKM1")]
         public static extern DL_STATUS SectorTrailerWrite_AKM1(byte addressing_mode,
                                         byte address,
                                         byte* new_key_A,
                                         byte block0_access_bits,
                                         byte block1_access_bits,
                                         byte block2_access_bits,
                                         byte sector_trailer_access_bits,
                                         byte sector_trailer_byte9,
                                         byte* new_key_B,
                                         byte auth_mode);

         [DllImport("uFCoder1x.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto, EntryPoint = "SectorTrailerWrite_AKM2")]
         public static extern DL_STATUS SectorTrailerWrite_AKM2(byte addressing_mode,
                                         byte address,
                                         byte* new_key_A,
                                         byte block0_access_bits,
                                         byte block1_access_bits,
                                         byte block2_access_bits,
                                         byte sector_trailer_access_bits,
                                         byte sector_trailer_byte9,
                                         byte* new_key_B,
                                         byte auth_mode);

         [DllImport("uFCoder1x.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto, EntryPoint = "SectorTrailerWrite_PK")]
         public static extern DL_STATUS SectorTrailerWrite_PK(byte addressing_mode,
                                         byte address,
                                         byte* new_key_A,
                                         byte block0_access_bits,
                                         byte block1_access_bits,
                                         byte block2_access_bits,
                                         byte sector_trailer_access_bits,
                                         byte sector_trailer_byte9,
                                         byte* new_key_B,
                                         byte auth_mode,
                                         byte* pk_key);

        [DllImport("uFCoder1x.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto, EntryPoint = "LinearFormatCard")]
       public static extern DL_STATUS  LinearFormatCard(byte* new_key_A,
                                                        byte blocks_access_bits,
                                                        byte sector_trailers_access_bits,
                                                        byte sector_trailers_byte9,
                                                        byte* new_key_B,
                                                        byte* sectors_formatted,
                                                        byte auth_mode,
                                                        byte key_index);

        [DllImport("uFCoder1x.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto, EntryPoint = "LinearFormatCard_AKM1")]
        public static extern DL_STATUS LinearFormatCard_AKM1(byte* new_key_A,
                                                         byte blocks_access_bits,
                                                         byte sector_trailers_access_bits,
                                                         byte sector_trailers_byte9,
                                                         byte* new_key_B,
                                                         byte* sectors_formatted,
                                                         byte auth_mode);

        [DllImport("uFCoder1x.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto, EntryPoint = "LinearFormatCard_AKM2")]
        public static extern DL_STATUS LinearFormatCard_AKM2(byte* new_key_A,
                                                         byte blocks_access_bits,
                                                         byte sector_trailers_access_bits,
                                                         byte sector_trailers_byte9,
                                                         byte* new_key_B,
                                                         byte* sectors_formatted,
                                                         byte auth_mode);
        [DllImport("uFCoder1x.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto, EntryPoint = "LinearFormatCard_PK")]
        public static extern DL_STATUS LinearFormatCard_PK(byte* new_key_A,
                                                         byte blocks_access_bits,
                                                         byte sector_trailers_access_bits,
                                                         byte sector_trailers_byte9,
                                                         byte* new_key_B,
                                                         byte* sectors_formatted,
                                                         byte auth_mode,                                        
                                                         byte* pk_key);

    }
}
